/**
 * @section LICENSE
 *
 * (C) Copyright 2011~2015 Bosch Sensortec GmbH All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 *------------------------------------------------------------------------------
 *  Disclaimer
 *
 * Common: Bosch Sensortec products are developed for the consumer goods
 * industry. They may only be used within the parameters of the respective valid
 * product data sheet.  Bosch Sensortec products are provided with the express
 * understanding that there is no warranty of fitness for a particular purpose.
 * They are not fit for use in life-sustaining, safety or security sensitive
 * systems or any system or device that may lead to bodily harm or property
 * damage if the system or device malfunctions. In addition, Bosch Sensortec
 * products are not fit for use in products which interact with motor vehicle
 * systems.  The resale and/or use of products are at the purchaser's own risk
 * and his own responsibility. The examination of fitness for the intended use
 * is the sole responsibility of the Purchaser.
 *
 * The purchaser shall indemnify Bosch Sensortec from all third party claims,
 * including any claims for incidental, or consequential damages, arising from
 * any product use not covered by the parameters of the respective valid product
 * data sheet or not approved by Bosch Sensortec and reimburse Bosch Sensortec
 * for all costs in connection with such claims.
 *
 * The purchaser must monitor the market for the purchased products,
 * particularly with regard to product safety and inform Bosch Sensortec without
 * delay of all security relevant incidents.
 *
 * Engineering Samples are marked with an asterisk (*) or (e). Samples may vary
 * from the valid technical specifications of the product series. They are
 * therefore not intended or fit for resale to third parties or for use in end
 * products. Their sole purpose is internal client testing. The testing of an
 * engineering sample may in no way replace the testing of a product series.
 * Bosch Sensortec assumes no liability for the use of engineering samples. By
 * accepting the engineering samples, the Purchaser agrees to indemnify Bosch
 * Sensortec from all claims arising from the use of engineering samples.
 *
 * Special: This software module (hereinafter called "Software") and any
 * information on application-sheets (hereinafter called "Information") is
 * provided free of charge for the sole purpose to support your application
 * work. The Software and Information is subject to the following terms and
 * conditions:
 *
 * The Software is specifically designed for the exclusive use for Bosch
 * Sensortec products by personnel who have special experience and training. Do
 * not use this Software if you do not have the proper experience or training.
 *
 * This Software package is provided `` as is `` and without any expressed or
 * implied warranties, including without limitation, the implied warranties of
 * merchantability and fitness for a particular purpose.
 *
 * Bosch Sensortec and their representatives and agents deny any liability for
 * the functional impairment of this Software in terms of fitness, performance
 * and safety. Bosch Sensortec and their representatives and agents shall not be
 * liable for any direct or indirect damages or injury, except as otherwise
 * stipulated in mandatory applicable law.
 *
 * The Information provided is believed to be accurate and reliable. Bosch
 * Sensortec assumes no responsibility for the consequences of use of such
 * Information nor for any infringement of patents or other rights of third
 * parties which may result from its use.
 *
 * @file         sensord_algo.cpp
 * @date         "Wed Dec 30 17:36:32 2015 +0800"
 * @commit       "1b27ca3"
 *
 * @brief
 *
 * @detail
 *
 */

#include <unistd.h>
#include <stdlib.h>
#include <string.h>
#include <errno.h>
#include <ctype.h>
#include <sys/types.h>
#include <stdarg.h>

#include "BstSensor.h"

#include "sensord_pltf.h"
#include "sensord_cfg.h"
#include "sensord_algo.h"
#include "sensord_hwcntl.h"
#include "util_misc.h"

#define SAMPLERATE_A  100.f
#define SAMPLERATE_B  25.f
#define SAMPLERATE_W  100.f

#define CONVERT_ACC (0.0098) //library output is in mg = 0.0098 m/s^2
#define CONVERT_GYRO (0.001065)
#define CONVERT_MAG (0.1)
#define CONVERT_ORI (57.2958)
#define CONVERT_GRAVITY (9.80665)

#define CVS_LIST (PATH_DIR_SENSOR_STORAGE "/csv_load_list.txt")
#define PROFILE_CALIB_A (PATH_DIR_SENSOR_STORAGE "/profile_calib_a.csv")
#define PROFILE_CALIB_M (PATH_DIR_SENSOR_STORAGE "/profile_calib_m.csv")
#define PROFILE_CALIB_G (PATH_DIR_SENSOR_STORAGE "/profile_calib_g.csv")

#define HAS_ACC 0x1
#define HAS_MAG 0x2
#define HAS_GYR 0x4

//output -- buffer for bsx_get_xyz function //TODO: dimension to be verified
BSX_CREATE_FIFO_LOCAL(fifo_data0, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data1, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data2, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data3, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data4, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data5, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data6, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data7, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data8, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data9, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data10, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data11, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data12, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data13, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data14, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data15, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data16, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data17, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data18, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data19, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data20, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data21, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data22, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data23, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data24, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data25, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data26, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data27, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data28, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data29, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data30, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data31, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data32, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data33, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data34, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data35, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data36, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data37, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data38, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data39, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data40, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data41, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data42, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data43, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data44, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);
BSX_CREATE_FIFO_LOCAL(fifo_data45, BSX_BUFFER_TYPE_UNKNOWN, 5, 1);

static bsx_fifo_data_t library_out_package[46];

static bsx_instance_t bsx_instance;

typedef struct
{
    bsx_u16_t supl_id;
    int32_t bsx_sensorid;
    int32_t android_sensortype;
} BSX_SPLID_MAPTBL;

typedef struct
{
    float x_bias;
    float y_bias;
    float z_bias;
} BSX_CALIBRATE_OFFSET;

typedef struct
{
    bsx_s32_t x;
    bsx_s32_t y;
    bsx_s32_t z;
    bsx_ts_external_t t;
} BSX_DATALOG_BUF;


static BSX_CALIBRATE_OFFSET gyro_cali_off = { 0.0, 0.0, 0.0 };
static BSX_CALIBRATE_OFFSET magn_cali_off = { 0.0, 0.0, 0.0 };

static const BSX_SPLID_MAPTBL bsx_splid_maptbl[] = {
        { BSX_OUTPUT_ID_ACCELERATION_CORRECTED, BSX_SENSOR_ID_ACCELEROMETER, SENSOR_TYPE_ACCELEROMETER },
        { BSX_OUTPUT_ID_MAGNETICFIELD_CORRECTED, BSX_SENSOR_ID_MAGNETIC_FIELD, SENSOR_TYPE_MAGNETIC_FIELD },
        { BSX_OUTPUT_ID_ORIENTATION, BSX_SENSOR_ID_ORIENTATION, SENSOR_TYPE_ORIENTATION },
        { BSX_OUTPUT_ID_ANGULARRATE_CORRECTED, BSX_SENSOR_ID_GYROSCOPE, SENSOR_TYPE_GYROSCOPE },
        { BSX_OUTPUT_ID_GRAVITY, BSX_SENSOR_ID_GRAVITY, SENSOR_TYPE_GRAVITY },
        { BSX_OUTPUT_ID_LINEARACCELERATION, BSX_SENSOR_ID_LINEAR_ACCELERATION, SENSOR_TYPE_LINEAR_ACCELERATION },
        { BSX_OUTPUT_ID_ROTATION, BSX_SENSOR_ID_ROTATION_VECTOR, SENSOR_TYPE_ROTATION_VECTOR },
        { BSX_OUTPUT_ID_MAGNETICFIELD_RAW, BSX_SENSOR_ID_MAGNETIC_FIELD_UNCALIBRATED, SENSOR_TYPE_MAGNETIC_FIELD_UNCALIBRATED },
        { BSX_OUTPUT_ID_ROTATION_GAME, BSX_SENSOR_ID_GAME_ROTATION_VECTOR, SENSOR_TYPE_GAME_ROTATION_VECTOR },
        { BSX_OUTPUT_ID_ANGULARRATE_RAW, BSX_SENSOR_ID_GYROSCOPE_UNCALIBRATED, SENSOR_TYPE_GYROSCOPE_UNCALIBRATED },
        { BSX_OUTPUT_ID_STEPDETECTOR, BSX_SENSOR_ID_STEP_DETECTOR, SENSOR_TYPE_STEP_DETECTOR},
        { BSX_OUTPUT_ID_STEPCOUNTER, BSX_SENSOR_ID_STEP_COUNTER, SENSOR_TYPE_STEP_COUNTER},
        { BSX_OUTPUT_ID_ROTATION_GEOMAGNETIC, BSX_SENSOR_ID_GEOMAGNETIC_ROTATION_VECTOR, SENSOR_TYPE_GEOMAGNETIC_ROTATION_VECTOR },
        { BSX_OUTPUT_ID_MAGNETICFIELD_OFFSET, 0, 0 }, //offset is invalid sensor
        { BSX_OUTPUT_ID_ANGULARRATE_OFFSET, 0, 0 }, //offset is invalid sensor

        { BSX_WAKEUP_ID_ACCELERATION_CORRECTED, BSX_SENSOR_ID_ACCELEROMETER_WAKEUP, SENSOR_TYPE_ACCELEROMETER},
        { BSX_WAKEUP_ID_MAGNETICFIELD_CORRECTED, BSX_SENSOR_ID_MAGNETIC_FIELD_WAKEUP, SENSOR_TYPE_MAGNETIC_FIELD},
        { BSX_WAKEUP_ID_ORIENTATION, BSX_SENSOR_ID_ORIENTATION_WAKEUP, SENSOR_TYPE_ORIENTATION },
        { BSX_WAKEUP_ID_ANGULARRATE_CORRECTED, BSX_SENSOR_ID_GYROSCOPE_WAKEUP, SENSOR_TYPE_GYROSCOPE },
        { BSX_WAKEUP_ID_GRAVITY, BSX_SENSOR_ID_GRAVITY_WAKEUP, SENSOR_TYPE_GRAVITY },
        { BSX_WAKEUP_ID_LINEARACCELERATION, BSX_SENSOR_ID_LINEAR_ACCELERATION_WAKEUP, SENSOR_TYPE_LINEAR_ACCELERATION },
        { BSX_WAKEUP_ID_ROTATION, BSX_SENSOR_ID_ROTATION_VECTOR_WAKEUP, SENSOR_TYPE_ROTATION_VECTOR },
        { BSX_WAKEUP_ID_ROTATION_GEOMAGNETIC, BSX_SENSOR_ID_GEOMAGNETIC_ROTATION_VECTOR_WAKEUP, SENSOR_TYPE_GEOMAGNETIC_ROTATION_VECTOR },
        { BSX_WAKEUP_ID_MAGNETICFIELD_RAW, BSX_SENSOR_ID_MAGNETIC_FIELD_UNCALIBRATED_WAKEUP, SENSOR_TYPE_MAGNETIC_FIELD_UNCALIBRATED },
        { BSX_WAKEUP_ID_ROTATION_GAME, BSX_SENSOR_ID_GAME_ROTATION_VECTOR_WAKEUP, SENSOR_TYPE_GAME_ROTATION_VECTOR },
        { BSX_WAKEUP_ID_ANGULARRATE_RAW, BSX_SENSOR_ID_GYROSCOPE_UNCALIBRATED_WAKEUP, SENSOR_TYPE_GYROSCOPE_UNCALIBRATED },
        { BSX_OUTPUT_ID_SIGNIFICANTMOTION_STATUS, BSX_SENSOR_ID_SIGNIFICANT_MOTION_WAKEUP, SENSOR_TYPE_SIGNIFICANT_MOTION },
        /*No wakeup step detector id in BSX4 library*/
        { BSX_WAKEUP_ID_STEPCOUNTER, BSX_SENSOR_ID_STEP_COUNTER_WAKEUP, SENSOR_TYPE_STEP_COUNTER},
        { BSX_OUTPUT_ID_TILT_STATUS, BSX_SENSOR_ID_TILT_DETECTOR_WAKEUP, SENSOR_TYPE_TILT_DETECTOR },
        { BSX_OUTPUT_ID_ACTIVITY, BSX_SENSOR_ID_ACTIVITY, SENSOR_TYPE_BOSCH_ACTIVITY_RECOGNITION },
        { BSX_OUTPUT_ID_WAKE_STATUS, BSX_SENSOR_ID_WAKE_GESTURE_WAKEUP, SENSOR_TYPE_WAKE_GESTURE },
        { BSX_OUTPUT_ID_GLANCE_STATUS, BSX_SENSOR_ID_GLANCE_GESTURE_WAKEUP, SENSOR_TYPE_GLANCE_GESTURE },
        { BSX_OUTPUT_ID_PICKUP_STATUS, BSX_SENSOR_ID_PICK_UP_GESTURE_WAKEUP, SENSOR_TYPE_PICK_UP_GESTURE },
};

static bsx_u8_t config_str_buf[2048] = {0};
static bsx_u32_t config_str_len = 0;

static bsx_u8_t work_buffer[512] = { 0 };
static bsx_u32_t work_buffer_size = sizeof(work_buffer);

static bsx_u8_t state_string[2048] = {0};
static bsx_u32_t state_string_size = 0;

static int8_t acc_accuarcy_status = SENSOR_STATUS_UNRELIABLE;
static int8_t mag_accuarcy_status = SENSOR_STATUS_UNRELIABLE;
static int8_t gyr_accuarcy_status = SENSOR_STATUS_UNRELIABLE;

static BstSensor *this_bstsensor = NULL;

/**
 * read @param filename, store the content to @param config_str_buf with max length @param buf_len.
 * @param p_str_len indicates valid length
 * @return 0 means OK
 */
static int32_t sensord_get_confstr(const char *filename, bsx_u8_t *config_str_buf, bsx_size_t buf_len, bsx_u32_t *p_str_len)
{
    FILE* fp = NULL;
    int32_t ret;
    uint32_t i;

    fp = fopen(filename, "r");
    if (fp)
    {
        for (i = 0; i < buf_len; ++i)
        {
            ret = fscanf(fp, "%3hhu,", &config_str_buf[i]);
            if(EOF == ret)
            {
                *p_str_len = i;
                fclose(fp);
                return 0;
            }
        }

        if(buf_len == i)
        {
            PERR("file %s is logner than buffer(len: %u)", filename, buf_len);
        }else
        {
            PERR("fscanf failed at %dth element", i);
        }

        fclose(fp);
        return -1;
    }
    else
    {
        PERR("open file %s failed, errno = %d", filename, errno);
        return -1;
    }
}


/**
 * write the configure string in @param config_str_buf with length @param buf_len to file @param filename
 * @return
 */
static int32_t sensord_save_confstr(const char *filename, const bsx_u8_t * const config_str_buf, const bsx_size_t buf_len)
{
    FILE* fp = NULL;
    uint32_t i;

    fp = fopen(filename, "w");
    if (fp)
    {
        for (i = 0; i < buf_len; ++i)
        {
            fprintf(fp, "%hhu,", config_str_buf[i]);
        }

        fclose(fp);
        return 0;
    }
    else
    {
        PERR("open file %s failed, errno = %d \n", filename, errno);
        return -1;
    }
}

/**
 * load all csv to library based on a file list "csv_load_list.txt"
 */
static void sensord_load_serialized_string()
{
    char csv_name[256] = {0};

    bsx_return_t bsx_ret;
    int32_t ret;

    FILE *fp = NULL;
    char *line = NULL;
    char *start = NULL;
    char *end = NULL;
    size_t len = 0;

    fp = fopen(CVS_LIST, "r");
    if (NULL == fp)
    {
        PERR("open %s failed, errno = %d", CVS_LIST, errno);
        return;
    }

    while ((ret = getline(&line, &len, fp)) != -1)
    {
        start = line;
        /*lskip*/
        while (*start && isspace((int) (*start)))
        {
            start++;
        }

        if(0 == *start)
        {
            //blank line in file, omit it
            continue;
        }else
        {
            /*strip \n in end*/
            end = start + strlen(start) - 1;
            *end = 0;

            snprintf(csv_name, sizeof(csv_name), "%s/%s", PATH_DIR_SENSOR_STORAGE, start);

            ret = sensord_get_confstr(csv_name, config_str_buf, sizeof(config_str_buf), &config_str_len);
            if (0 != ret)
            {
                PERR("get configuration %s fail, ret = %d", csv_name, ret);
                continue;
            }

            PINFO("set serialized string %s", csv_name);

            bsx_ret = bsx_set_configuration(&bsx_instance, config_str_buf, config_str_len, work_buffer, work_buffer_size);
            if (BSX_OK != bsx_ret)
            {
                PERR("bsx_set_configuration  %s fail, ret = %d", csv_name, bsx_ret);
            }
        }
    }

    fclose(fp);
    free(line);

    return;
}



/**
 * if there is calibation profile, then set the profile(in form of state string) to library
 */
static void sensord_restore_calib_profile()
{
    bsx_return_t bsx_ret;
    int32_t ret;

    if(0 == access(PROFILE_CALIB_A, F_OK))
    {
        ret = sensord_get_confstr(PROFILE_CALIB_A, state_string, sizeof(state_string), &state_string_size);
        if (0 != ret)
        {
            PERR("get profile fail, ret = %d", ret);
        }else
        {
            bsx_ret = bsx_set_state(&bsx_instance, state_string, state_string_size, work_buffer, work_buffer_size);
            if (BSX_OK != bsx_ret)
            {
                PERR("bsx_set_state fail, ret = %d \n", bsx_ret);
            }

            PDEBUG("set acc calib: %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u... len = %u",
                    state_string[0], state_string[1], state_string[2], state_string[3], state_string[4],
                    state_string[5], state_string[6], state_string[7], state_string[8], state_string[9],
                    state_string[10], state_string[11], state_string[12], state_string[13], state_string[14],
                    state_string[15], state_string_size);
        }
    }

    if(0 == access(PROFILE_CALIB_M, F_OK))
    {
        ret = sensord_get_confstr(PROFILE_CALIB_M, state_string, sizeof(state_string), &state_string_size);
        if (0 != ret)
        {
            PERR("get profile fail, ret = %d", ret);
        }else
        {
            bsx_ret = bsx_set_state(&bsx_instance, state_string, state_string_size, work_buffer, work_buffer_size);
            if (BSX_OK != bsx_ret)
            {
                PERR("bsx_set_state fail, ret = %d \n", bsx_ret);
            }

            PDEBUG("set mag calib: %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u... len = %u",
                    state_string[0], state_string[1], state_string[2], state_string[3], state_string[4],
                    state_string[5], state_string[6], state_string[7], state_string[8], state_string[9],
                    state_string[10], state_string[11], state_string[12], state_string[13], state_string[14],
                    state_string[15], state_string_size);
        }
    }

    if(0 == access(PROFILE_CALIB_G, F_OK))
    {
        ret = sensord_get_confstr(PROFILE_CALIB_G, state_string, sizeof(state_string), &state_string_size);
        if (0 != ret)
        {
            PERR("get profile fail, ret = %d", ret);
        }else
        {
            bsx_ret = bsx_set_state(&bsx_instance, state_string, state_string_size, work_buffer, work_buffer_size);
            if (BSX_OK != bsx_ret)
            {
                PERR("bsx_set_state fail, ret = %d \n", bsx_ret);
            }

            PDEBUG("set gyr calib: %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u, %u... len = %u",
                    state_string[0], state_string[1], state_string[2], state_string[3], state_string[4],
                    state_string[5], state_string[6], state_string[7], state_string[8], state_string[9],
                    state_string[10], state_string[11], state_string[12], state_string[13], state_string[14],
                    state_string[15], state_string_size);
        }
    }

    return;
}


/*!
 * @brief This function loads spec files from file system and set them into
 *            bsx_init, after that it calls algo_adapter_init to set up
 *            sensor_hw and working modes
 *
 * @param none
 *
 * @return 0 success, < 0 failed
 */
int sensord_bsx_init(void)
{
    bsx_return_t bsx_ret;

    /* Library Initialization (precondition - set precompiler & debug settings)*/
    bsx_ret = bsx_init(&bsx_instance);
    if (BSX_OK != bsx_ret)
    {
        PERR("bsx_init fail, ret = %d", bsx_ret);
        return bsx_ret;
    }

    sensord_load_serialized_string();

    sensord_restore_calib_profile();

    library_out_package[0] = bsx_fifo_data0;
    library_out_package[1] = bsx_fifo_data1;
    library_out_package[2] = bsx_fifo_data2;
    library_out_package[3] = bsx_fifo_data3;
    library_out_package[4] = bsx_fifo_data4;
    library_out_package[5] = bsx_fifo_data5;
    library_out_package[6] = bsx_fifo_data6;
    library_out_package[7] = bsx_fifo_data7;
    library_out_package[8] = bsx_fifo_data8;
    library_out_package[9] = bsx_fifo_data9;
    library_out_package[10] = bsx_fifo_data10;
    library_out_package[11] = bsx_fifo_data11;
    library_out_package[12] = bsx_fifo_data12;
    library_out_package[13] = bsx_fifo_data13;
    library_out_package[14] = bsx_fifo_data14;
    library_out_package[15] = bsx_fifo_data15;
    library_out_package[16] = bsx_fifo_data16;
    library_out_package[17] = bsx_fifo_data17;
    library_out_package[18] = bsx_fifo_data18;
    library_out_package[19] = bsx_fifo_data19;
    library_out_package[20] = bsx_fifo_data20;
    library_out_package[21] = bsx_fifo_data21;
    library_out_package[22] = bsx_fifo_data22;
    library_out_package[23] = bsx_fifo_data23;
    library_out_package[24] = bsx_fifo_data24;
    library_out_package[25] = bsx_fifo_data25;
    library_out_package[26] = bsx_fifo_data26;
    library_out_package[27] = bsx_fifo_data27;
    library_out_package[28] = bsx_fifo_data28;
    library_out_package[29] = bsx_fifo_data29;
    library_out_package[30] = bsx_fifo_data30;
    library_out_package[31] = bsx_fifo_data31;
    library_out_package[32] = bsx_fifo_data32;
    library_out_package[33] = bsx_fifo_data33;
    library_out_package[34] = bsx_fifo_data34;
    library_out_package[35] = bsx_fifo_data35;
    library_out_package[36] = bsx_fifo_data36;
    library_out_package[37] = bsx_fifo_data37;
    library_out_package[38] = bsx_fifo_data38;
    library_out_package[39] = bsx_fifo_data39;
    library_out_package[40] = bsx_fifo_data40;
    library_out_package[41] = bsx_fifo_data41;
    library_out_package[42] = bsx_fifo_data42;
    library_out_package[43] = bsx_fifo_data43;
    library_out_package[44] = bsx_fifo_data44;
    library_out_package[45] = bsx_fifo_data45;

    return 0;
}

static inline void get_Moffset_from_BSX_output(bsx_data_content_t *content_p)
{
    PINFO("get magnetic offset %f, %f, %f",
            content_p[0].lw.mslw.sfp,
            content_p[1].lw.mslw.sfp,
            content_p[2].lw.mslw.sfp);

    magn_cali_off.x_bias = content_p[0].lw.mslw.sfp;
    magn_cali_off.y_bias = content_p[1].lw.mslw.sfp;
    magn_cali_off.z_bias = content_p[2].lw.mslw.sfp;

    return;
}

static inline void get_Goffset_from_BSX_output(bsx_data_content_t *content_p)
{
    PINFO("get gyroscope offset %f, %f, %f",
            content_p[0].lw.mslw.sfp,
            content_p[1].lw.mslw.sfp,
            content_p[2].lw.mslw.sfp);

    gyro_cali_off.x_bias = content_p[0].lw.mslw.sfp;
    gyro_cali_off.y_bias = content_p[1].lw.mslw.sfp;
    gyro_cali_off.z_bias = content_p[2].lw.mslw.sfp;

    return;
}


/**
*32 bit unsigned integers of a detected activity (event)
*bit field, with 32 bit word for the activity type and its change where the
*   - 16 bit high word (MSW) is the activity change off
*   - 16 bit low word (LSW) is the activity change on
*   where the bits of each byte represent:
*   bit #0      still
*   bit #1      walking
*   bit #2      running
*   bit #3      on_bicycle
*   bit #4      in_vehicle
*   bit #5      tilting
*   bit #6-15   reserved
*in summary
*   bits  [31 . . . . 16  15. . . . 0]
*          activity off   activity on
*/
static void get_AR_from_BSX_output(bsx_fifo_data_t *bsx_fifo, BstSensor *bstsensor)
{
#define BIT_STILL       0
#define BIT_WALKING     1
#define BIT_RUNNING     2
#define BIT_ON_BICYCLE  3
#define BIT_IN_VEHICLE  4
#define BIT_TILTING     5

    /* Signifies entering an activity. */
#define ACTIVITY_EVENT_ENTER 1 //from <activity_recognition.h>
    /* Signifies exiting an activity. */
#define ACTIVITY_EVENT_EXIT 2 //from <activity_recognition.h>

#define ACTIVITY_STILL       0
#define ACTIVITY_WALKING     1
#define ACTIVITY_RUNNING     2
#define ACTIVITY_ON_BICYCLE  3
#define ACTIVITY_IN_VEHICLE  4
#define ACTIVITY_TILTING     5
    const int32_t bit_actid_map[] = {
            ACTIVITY_STILL, ACTIVITY_WALKING, ACTIVITY_RUNNING,
            ACTIVITY_ON_BICYCLE, ACTIVITY_IN_VEHICLE, ACTIVITY_TILTING
    };
    sensors_event_t *p_event = NULL;
    int16_t AR_low;
    int16_t AR_high;
    int32_t i;

    AR_low = (bsx_fifo->content_p[0].lw.mslw.uli) & 0xFFFF;
    AR_high = ((bsx_fifo->content_p[0].lw.mslw.uli) >> 16) & 0xFFFF;

    if(AR_low)
    {
        for (i = BIT_STILL; i <= BIT_TILTING; ++i)
        {
            if(AR_low & (1 << i))
            {
                p_event = (sensors_event_t *) calloc(1, sizeof(sensors_event_t));
                if (NULL == p_event)
                {
                    PWARN("calloc fail");
                    continue;
                }

                /** format is same with what used in BHy*/
                p_event->version = sizeof(sensors_event_t);
                p_event->sensor = BSX_SENSOR_ID_ACTIVITY;
                p_event->type = SENSOR_TYPE_BOSCH_ACTIVITY_RECOGNITION;
                p_event->data[0] = (float) ACTIVITY_EVENT_ENTER;
                p_event->data[1] = (float) bit_actid_map[i];
                p_event->data[2] = 0.0f;
                p_event->timestamp = bsx_fifo->time_stamp;

                bstsensor->sensord_deliver_event(p_event);
            }
        }
    }

    if(AR_high)
    {
        for (i = BIT_STILL; i <= BIT_TILTING; ++i)
        {
            if(AR_high & (1 << i))
            {
                p_event = (sensors_event_t *) calloc(1, sizeof(sensors_event_t));
                if (NULL == p_event)
                {
                    PWARN("calloc fail");
                    continue;
                }

                /** format is same with what used in BHy*/
                p_event->version = sizeof(sensors_event_t);
                p_event->sensor = BSX_SENSOR_ID_ACTIVITY;
                p_event->type = SENSOR_TYPE_BOSCH_ACTIVITY_RECOGNITION;
                p_event->data[0] = (float) ACTIVITY_EVENT_EXIT;
                p_event->data[1] = (float) bit_actid_map[i];
                p_event->data[2] = 0.0f;
                p_event->timestamp = bsx_fifo->time_stamp;

                bstsensor->sensord_deliver_event(p_event);
            }
        }
    }

    return;
}


/**
 *
 * @param supl_id
 * @param p_sensorid
 * @param p_sensortype
 */
static inline void convert_BSX_supplierid(bsx_u16_t supl_id, int32_t *p_sensorid, int32_t *p_sensortype)
{

    int loop;
    int i;

    *p_sensorid = 0;
    *p_sensortype = 0;

    loop = ARRAY_ELEMENTS(bsx_splid_maptbl);

    for (i = 0; i < loop; i++)
    {

        if (bsx_splid_maptbl[i].supl_id == supl_id)
        {
            *p_sensorid = bsx_splid_maptbl[i].bsx_sensorid;
            *p_sensortype = bsx_splid_maptbl[i].android_sensortype;
        }
    }

    return;
}


/**
 * the output format of bsx_fifo->content_p, please refer <<bsx4_outputgates_format.xlsx>>
 * @param bsx_fifo
 * @param simple_listDest
 */
static void convert_BSX_output(bsx_fifo_data_t *bsx_fifo, BstSensor *bstsensor)
{
    sensors_event_t *p_event = NULL;
    int32_t bsx_sensor_id;
    int32_t sensor_type;
    char data_log_buf[1024] = { 0 };

    if (0 == bsx_fifo->time_stamp)
    {
        /*output is found, but no valid data, skip*/
        PWARN("output is found, but no valid data, skip. (bsx_fifo->sensor_id = %u)", bsx_fifo->sensor_id);
        return;
    }

    if (BSX_OUTPUT_ID_MAGNETICFIELD_OFFSET == bsx_fifo->sensor_id)
    {
        get_Moffset_from_BSX_output(bsx_fifo->content_p);
        return;
    }

    if (BSX_OUTPUT_ID_ANGULARRATE_OFFSET == bsx_fifo->sensor_id)
    {
        get_Goffset_from_BSX_output(bsx_fifo->content_p);
        return;
    }

    PINFO("==== output supplier_id: %d, dims: %d, depth: %d, time: %lld",
        bsx_fifo->sensor_id, bsx_fifo->dims, bsx_fifo->depth, bsx_fifo->time_stamp);

    /** Activity handler*/
    if (BSX_OUTPUT_ID_ACTIVITY == bsx_fifo->sensor_id)
    {
        get_AR_from_BSX_output(bsx_fifo, bstsensor);
        return;
    }

    /**
     * For other common sensor's output
     */
    convert_BSX_supplierid(bsx_fifo->sensor_id, &bsx_sensor_id, &sensor_type);
    if (0 == bsx_sensor_id)
    {
        /* not official sensor, to do something */
        PWARN("not supported supplier id: %u", bsx_fifo->sensor_id);
        return;
    }

    p_event = (sensors_event_t *) calloc(1, sizeof(sensors_event_t));
    if (NULL == p_event)
    {
        PWARN("calloc fail");
        return;
    }

    p_event->version = sizeof(sensors_event_t);
    p_event->sensor = bsx_sensor_id;
    p_event->type = sensor_type;

    switch (p_event->sensor)
    {
        case BSX_SENSOR_ID_ACCELEROMETER:
        case BSX_SENSOR_ID_ACCELEROMETER_WAKEUP:
            p_event->acceleration.x = bsx_fifo->content_p[0].lw.mslw.sfp;
            p_event->acceleration.y = bsx_fifo->content_p[1].lw.mslw.sfp;
            p_event->acceleration.z = bsx_fifo->content_p[2].lw.mslw.sfp;
            p_event->acceleration.status = (int8_t) bsx_fifo->content_p[3].lw.mslw.sfp;
            acc_accuarcy_status = p_event->acceleration.status;
            if (data_log)
            {
                sprintf(data_log_buf, "%f, %f, %f, %lld %d\n",
                        p_event->acceleration.x,
                        p_event->acceleration.y,
                        p_event->acceleration.z,
                        bsx_fifo->time_stamp,
                        p_event->acceleration.status
                        );
                data_log_algo_output_A(data_log_buf);
            }
            break;
        case BSX_SENSOR_ID_LINEAR_ACCELERATION:
        case BSX_SENSOR_ID_LINEAR_ACCELERATION_WAKEUP:
            p_event->acceleration.x = bsx_fifo->content_p[0].lw.mslw.sfp;
            p_event->acceleration.y = bsx_fifo->content_p[1].lw.mslw.sfp;
            p_event->acceleration.z = bsx_fifo->content_p[2].lw.mslw.sfp;
            p_event->acceleration.status = (int8_t) bsx_fifo->content_p[3].lw.mslw.sfp;
            if (data_log)
            {
                sprintf(data_log_buf, "%f, %f, %f, %lld %d\n",
                        p_event->acceleration.x,
                        p_event->acceleration.y,
                        p_event->acceleration.z,
                        bsx_fifo->time_stamp,
                        p_event->acceleration.status
                        );
                data_log_algo_output_VLA(data_log_buf);
            }
            break;
        case BSX_SENSOR_ID_MAGNETIC_FIELD:
        case BSX_SENSOR_ID_MAGNETIC_FIELD_WAKEUP:
            p_event->magnetic.x = bsx_fifo->content_p[0].lw.mslw.sfp;
            p_event->magnetic.y = bsx_fifo->content_p[1].lw.mslw.sfp;
            p_event->magnetic.z = bsx_fifo->content_p[2].lw.mslw.sfp;
            p_event->magnetic.status = (int8_t) bsx_fifo->content_p[3].lw.mslw.sfp;
            mag_accuarcy_status = p_event->magnetic.status;
            if (data_log)
            {
                sprintf(data_log_buf, "%f, %f, %f, %lld %d\n",
                        p_event->magnetic.x,
                        p_event->magnetic.y,
                        p_event->magnetic.z,
                        bsx_fifo->time_stamp,
                        p_event->magnetic.status
                        );
                data_log_algo_output_M(data_log_buf);
            }
            break;
        case BSX_SENSOR_ID_ORIENTATION:
        case BSX_SENSOR_ID_ORIENTATION_WAKEUP:
            p_event->orientation.azimuth = bsx_fifo->content_p[3].lw.mslw.sfp * CONVERT_ORI;
            p_event->orientation.pitch = bsx_fifo->content_p[1].lw.mslw.sfp * CONVERT_ORI;
            p_event->orientation.roll = bsx_fifo->content_p[2].lw.mslw.sfp * CONVERT_ORI;
            //bsx_fifo->content_p[BSX_ZERO][0].lw.mslw.sfp = yaw, not used in Android
            p_event->orientation.status = (int8_t) bsx_fifo->content_p[4].lw.mslw.sfp;
            if (data_log)
            {
                sprintf(data_log_buf, "%f, %f, %f, %lld %d\n",
                        p_event->orientation.azimuth,
                        p_event->orientation.pitch,
                        p_event->orientation.roll,
                        bsx_fifo->time_stamp,
                        p_event->orientation.status
                        );
                data_log_algo_output_O(data_log_buf);
            }
            break;
        case BSX_SENSOR_ID_GYROSCOPE:
        case BSX_SENSOR_ID_GYROSCOPE_WAKEUP:
            p_event->gyro.x = bsx_fifo->content_p[0].lw.mslw.sfp;
            p_event->gyro.y = bsx_fifo->content_p[1].lw.mslw.sfp;
            p_event->gyro.z = bsx_fifo->content_p[2].lw.mslw.sfp;
            p_event->gyro.status = (int8_t) bsx_fifo->content_p[3].lw.mslw.sfp;
            gyr_accuarcy_status = p_event->gyro.status;
            if (data_log)
            {
                sprintf(data_log_buf, "%f, %f, %f, %lld %d\n",
                        p_event->gyro.x,
                        p_event->gyro.y,
                        p_event->gyro.z,
                        bsx_fifo->time_stamp,
                        p_event->gyro.status
                        );
                data_log_algo_output_G(data_log_buf);
            }
            break;
        case BSX_SENSOR_ID_GRAVITY:
        case BSX_SENSOR_ID_GRAVITY_WAKEUP:
            p_event->acceleration.x = bsx_fifo->content_p[0].lw.mslw.sfp;
            p_event->acceleration.y = bsx_fifo->content_p[1].lw.mslw.sfp;
            p_event->acceleration.z = bsx_fifo->content_p[2].lw.mslw.sfp;
            p_event->acceleration.status = (int8_t) bsx_fifo->content_p[3].lw.mslw.sfp;
            if (data_log)
            {
                sprintf(data_log_buf, "%f, %f, %f, %lld %d\n",
                        p_event->acceleration.x,
                        p_event->acceleration.y,
                        p_event->acceleration.z,
                        bsx_fifo->time_stamp,
                        p_event->acceleration.status
                        );
                data_log_algo_output_VG(data_log_buf);
            }
            break;
        case BSX_SENSOR_ID_ROTATION_VECTOR:
        case BSX_SENSOR_ID_ROTATION_VECTOR_WAKEUP:
            case BSX_SENSOR_ID_GEOMAGNETIC_ROTATION_VECTOR:
            case BSX_SENSOR_ID_GEOMAGNETIC_ROTATION_VECTOR_WAKEUP:
            p_event->data[0] = bsx_fifo->content_p[0].lw.mslw.sfp;
            p_event->data[1] = bsx_fifo->content_p[1].lw.mslw.sfp;
            p_event->data[2] = bsx_fifo->content_p[2].lw.mslw.sfp;
            p_event->data[3] = bsx_fifo->content_p[3].lw.mslw.sfp;
            /**In addition, this sensor reports an estimated heading accuracy:
            sensors_event_t.data[4] = estimated_accuracy (in radians)*/
            p_event->data[4] = bsx_fifo->content_p[4].lw.mslw.sfp;
            break;
        case BSX_SENSOR_ID_MAGNETIC_FIELD_UNCALIBRATED:
        case BSX_SENSOR_ID_MAGNETIC_FIELD_UNCALIBRATED_WAKEUP:
            p_event->uncalibrated_magnetic.x_uncalib = bsx_fifo->content_p[0].lw.mslw.sfp;
            p_event->uncalibrated_magnetic.y_uncalib = bsx_fifo->content_p[1].lw.mslw.sfp;
            p_event->uncalibrated_magnetic.z_uncalib = bsx_fifo->content_p[2].lw.mslw.sfp;
            p_event->uncalibrated_magnetic.x_bias = magn_cali_off.x_bias;
            p_event->uncalibrated_magnetic.y_bias = magn_cali_off.y_bias;
            p_event->uncalibrated_magnetic.z_bias = magn_cali_off.z_bias;
            break;
        case BSX_SENSOR_ID_GAME_ROTATION_VECTOR:
        case BSX_SENSOR_ID_GAME_ROTATION_VECTOR_WAKEUP:
            p_event->data[0] = bsx_fifo->content_p[0].lw.mslw.sfp;
            p_event->data[1] = bsx_fifo->content_p[1].lw.mslw.sfp;
            p_event->data[2] = bsx_fifo->content_p[2].lw.mslw.sfp;
            p_event->data[3] = bsx_fifo->content_p[3].lw.mslw.sfp;
            /** This sensor does not report an estimated heading accuracy: sensors_event_t.data[4] is
             * reserved and should be set to 0.
             */
            p_event->data[4] = 0.0;
            break;
        case BSX_SENSOR_ID_GYROSCOPE_UNCALIBRATED:
        case BSX_SENSOR_ID_GYROSCOPE_UNCALIBRATED_WAKEUP:
            p_event->uncalibrated_gyro.x_uncalib = bsx_fifo->content_p[0].lw.mslw.sfp;
            p_event->uncalibrated_gyro.y_uncalib = bsx_fifo->content_p[1].lw.mslw.sfp;
            p_event->uncalibrated_gyro.z_uncalib = bsx_fifo->content_p[2].lw.mslw.sfp;
            p_event->uncalibrated_gyro.x_bias = gyro_cali_off.x_bias;
            p_event->uncalibrated_gyro.y_bias = gyro_cali_off.y_bias;
            p_event->uncalibrated_gyro.z_bias = gyro_cali_off.z_bias;
            break;
        case BSX_SENSOR_ID_STEP_COUNTER:
        case BSX_SENSOR_ID_STEP_COUNTER_WAKEUP:
            p_event->u64.step_counter = bsx_fifo->content_p[0].ulli;
            break;
        case BSX_SENSOR_ID_STEP_DETECTOR:
        case BSX_SENSOR_ID_SIGNIFICANT_MOTION_WAKEUP:
        case BSX_SENSOR_ID_TILT_DETECTOR_WAKEUP:
        case BSX_SENSOR_ID_WAKE_GESTURE_WAKEUP:
        case BSX_SENSOR_ID_GLANCE_GESTURE_WAKEUP:
        case BSX_SENSOR_ID_PICK_UP_GESTURE_WAKEUP:
            p_event->data[0] = 1;
            break;

        default:
            /*sensor not supported now*/
            free(p_event);
            return;
    }

    p_event->timestamp = bsx_fifo->time_stamp;

    bstsensor->sensord_deliver_event(p_event);

    return;

}



//declare i/p buffer
/// accel data
bsx_data_content_t accel_sli_in_xyz[3] =
{
    {   .slli = 0},
    {   .slli = 0},
    {   .slli = 0}};

bsx_fifo_data_t accel_in_data =
        {
                0, /* timestamp */
                accel_sli_in_xyz,
                #if 1
                BSX_BUFFER_TYPE_S32, /* data type */
#else
                BSX_BUFFER_TYPE_FLONG, /* data type */
#endif
                BSX_INPUT_ID_ACCELERATION,
                3, /* dims */
                1, /* depth */
        };

/// mag test data
bsx_data_content_t mag_sli_in_xyz[3] =
{
    {   .slli = 0},
    {   .slli = 0},
    {   .slli = 0}};

bsx_fifo_data_t mag_in_data =
        {
                0, /* timestamp */
                mag_sli_in_xyz,
                #if 1
                BSX_BUFFER_TYPE_S32, /* data type */
#else
                BSX_BUFFER_TYPE_FLONG, /* data type */
#endif
                BSX_INPUT_ID_MAGNETICFIELD,
                3, /* dims */
                1, /* depth */
        };

/// ang test data
bsx_data_content_t ang_sli_in_xyz[3] =
{
    {   .slli = 0},
    {   .slli = 0},
    {   .slli = 0}};

bsx_fifo_data_t ang_in_data =
        {
                0, /* timestamp */
                ang_sli_in_xyz,
                #if 1
                BSX_BUFFER_TYPE_S32, /* data type */
#else
                BSX_BUFFER_TYPE_FLONG, /* data type */
#endif
                BSX_INPUT_ID_ANGULARRATE,
                3, /* dims */
                1, /* depth */

        };

/// library input package
static bsx_fifo_data_t library_in_package[3];


/**
 * generate an align indication array @param p_align_ind XX XX XX XX... with length @param p_len
 * if @param p_align_ind [i] & HAS_ACC/HAS_MAG/HAS_GYR, then a acc/mag/gyro should be delivered
 * to libary at that postion.
 */
static void sort_input_samples(int8_t **pp_align_ind, uint32_t *p_len,
        HW_DATA_UNION **pp_ACC_hwdata, uint32_t ACC_hwdata_len,
        HW_DATA_UNION **pp_MAG_hwdata, uint32_t MAG_hwdata_len,
        HW_DATA_UNION **pp_GYRO_hwdata, uint32_t GYRO_hwdata_len)
{
    int64_t cur_base_tm = 0;
    int acc_cur_index = 0;
    int mag_cur_index = 0;
    int gyr_cur_index = 0;
    int pos = 0;

    if(0 == ACC_hwdata_len + MAG_hwdata_len + GYRO_hwdata_len)
    {
        *p_len = 0;
        return;
    }

    (*pp_align_ind) = (int8_t *)calloc(ACC_hwdata_len + MAG_hwdata_len + GYRO_hwdata_len, 1);
    if(NULL == (*pp_align_ind))
    {
        *p_len = 0;
        PERR("calloc fail");
        return;
    }

    while(ACC_hwdata_len + MAG_hwdata_len + GYRO_hwdata_len)
    {
        /** firstly find out the current tm base as the alignment standard*/
        cur_base_tm = 0;

        if(GYRO_hwdata_len){
            cur_base_tm = pp_GYRO_hwdata[gyr_cur_index]->timestamp;
        }

        if(ACC_hwdata_len)
        {
            if(cur_base_tm)
            {
                if(pp_ACC_hwdata[acc_cur_index]->timestamp < cur_base_tm){
                    cur_base_tm = pp_ACC_hwdata[acc_cur_index]->timestamp;
                }
            }else{
                cur_base_tm = pp_ACC_hwdata[acc_cur_index]->timestamp;
            }
        }

        if(MAG_hwdata_len)
        {
            if(cur_base_tm)
            {
                if(pp_MAG_hwdata[mag_cur_index]->timestamp < cur_base_tm){
                    cur_base_tm = pp_MAG_hwdata[mag_cur_index]->timestamp;
                }
            }else{
                cur_base_tm = pp_MAG_hwdata[mag_cur_index]->timestamp;
            }
        }

        /**Then the raw data can be aligned according to the currect tm base*/
        if(ACC_hwdata_len)
        {
            if(pp_ACC_hwdata[acc_cur_index]->timestamp == cur_base_tm)
            {
                (*pp_align_ind)[pos] |= HAS_ACC;
                acc_cur_index++;
                ACC_hwdata_len--;
            }
        }

        if(MAG_hwdata_len)
        {
            if(pp_MAG_hwdata[mag_cur_index]->timestamp == cur_base_tm)
            {
                (*pp_align_ind)[pos] |= HAS_MAG;
                mag_cur_index++;
                MAG_hwdata_len--;
            }
        }

        if(GYRO_hwdata_len)
        {
            if(pp_GYRO_hwdata[gyr_cur_index]->timestamp == cur_base_tm)
            {
                (*pp_align_ind)[pos] |= HAS_GYR;
                gyr_cur_index++;
                GYRO_hwdata_len--;
            }
        }

        pos++;
    }

    *p_len = pos;

    return;
}

/**
 * free thoroughly the hwdata
 */
static void distory_hwdata(HW_DATA_UNION **pp_hwdata, uint32_t hwdata_len)
{
    uint32_t i;

    if(NULL == pp_hwdata)
    {
        return;
    }

    for (i = 0; i < hwdata_len; ++i) {
        free(pp_hwdata[i]);
    }

    free(pp_hwdata);
}

static int32_t start_AG_gap_check = 0;
static int32_t start_M_gap_check = 0;

void sensord_algo_process(BstSensor *bstsensor)
{
    uint32_t i;
    uint32_t j;
    static int64_t last_AG_prevtim = 0;
    static int64_t last_M_prevtim = 0;
    HW_DATA_UNION **pp_ACC_hwdata = NULL;
    uint32_t ACC_hwdata_len = 0;
    HW_DATA_UNION **pp_MAG_hwdata = NULL;
    uint32_t MAG_hwdata_len = 0;
    HW_DATA_UNION **pp_GYRO_hwdata = NULL;
    uint32_t GYRO_hwdata_len = 0;
    int8_t *p_align_ind = NULL;
    uint32_t align_ind_len;
    int32_t ACC_hwdata_index;
    int32_t MAG_hwdata_index;
    int32_t GYRO_hwdata_index;

    bsx_return_t bsx_ret;
    bsx_u32_t nOutput;
    static int32_t log_max = 0;
    char data_log_buf[1024] = { 0 };
    uint32_t acc_has_input = 0;
    uint32_t mag_has_input = 0;
    uint32_t gyr_has_input = 0;
    uint32_t input_package_index = 0;
    sensors_event_t *p_event = NULL;
    BSX_DATALOG_BUF acc_log_data;
    BSX_DATALOG_BUF gyr_log_data;
    BSX_DATALOG_BUF mag_log_data;

    this_bstsensor = bstsensor;

    if(0 == bstsensor->tmplist_sensord_acclraw->list_len +
            bstsensor->tmplist_sensord_gyroraw->list_len +
            bstsensor->tmplist_sensord_magnraw->list_len)
    {
        return;
    }

    /**
     * Step 1 save the hardware data and generate align indication array
     */
    if(bstsensor->tmplist_sensord_acclraw->list_len)
    {
        pp_ACC_hwdata = (HW_DATA_UNION **)malloc(bstsensor->tmplist_sensord_acclraw->list_len * sizeof(HW_DATA_UNION *));
        if(NULL == pp_ACC_hwdata)
        {
            PWARN("malloc fail");
            return;
        }

        ACC_hwdata_len = bstsensor->tmplist_sensord_acclraw->list_len;
        for (i = 0; i < ACC_hwdata_len; ++i) {
            bstsensor->tmplist_sensord_acclraw->list_get_headdata((void **) &(pp_ACC_hwdata[i]));
        }
    }

    if(bstsensor->tmplist_sensord_magnraw->list_len)
    {
        pp_MAG_hwdata = (HW_DATA_UNION **)malloc(bstsensor->tmplist_sensord_magnraw->list_len * sizeof(HW_DATA_UNION *));
        if(NULL == pp_MAG_hwdata)
        {
            PWARN("malloc fail");
            distory_hwdata(pp_ACC_hwdata, ACC_hwdata_len);
            return;
        }

        MAG_hwdata_len = bstsensor->tmplist_sensord_magnraw->list_len;
        for (i = 0; i < MAG_hwdata_len; ++i) {
            bstsensor->tmplist_sensord_magnraw->list_get_headdata((void **) &(pp_MAG_hwdata[i]));
        }
    }

    if(bstsensor->tmplist_sensord_gyroraw->list_len)
    {
        pp_GYRO_hwdata = (HW_DATA_UNION **)malloc(bstsensor->tmplist_sensord_gyroraw->list_len * sizeof(HW_DATA_UNION *));
        if(NULL == pp_GYRO_hwdata)
        {
            PWARN("malloc fail");
            distory_hwdata(pp_ACC_hwdata, ACC_hwdata_len);
            distory_hwdata(pp_MAG_hwdata, MAG_hwdata_len);
            return;
        }

        GYRO_hwdata_len = bstsensor->tmplist_sensord_gyroraw->list_len;
        for (i = 0; i < GYRO_hwdata_len; ++i) {
            bstsensor->tmplist_sensord_gyroraw->list_get_headdata((void **) &(pp_GYRO_hwdata[i]));
        }
    }

    //PDEBUG("Acc len: %u, Gyro len: %u, Mag len: %u", simple_listAccl->list_len, simple_listGyro->list_len, simple_listMagn->list_len);

    sort_input_samples(&p_align_ind, &align_ind_len,
            pp_ACC_hwdata, ACC_hwdata_len,
            pp_MAG_hwdata, MAG_hwdata_len,
            pp_GYRO_hwdata, GYRO_hwdata_len);
    if(NULL == p_align_ind)
    {
        PWARN("sort_input_samples fail");
        distory_hwdata(pp_ACC_hwdata, ACC_hwdata_len);
        distory_hwdata(pp_MAG_hwdata, MAG_hwdata_len);
        distory_hwdata(pp_GYRO_hwdata, GYRO_hwdata_len);
        return;
    }

    /**
     * Step 2 deliver hardware data to library according to align indication array
     */
    ACC_hwdata_index = 0;
    MAG_hwdata_index = 0;
    GYRO_hwdata_index = 0;

    for (i = 0; i < align_ind_len; ++i)
    {
        acc_has_input = 0;
        gyr_has_input = 0;
        mag_has_input = 0;

        if(p_align_ind[i] & HAS_ACC)
        {
            acc_has_input = 1;
            accel_sli_in_xyz[0].lw.mslw.sli = pp_ACC_hwdata[ACC_hwdata_index]->x;
            accel_sli_in_xyz[1].lw.mslw.sli = pp_ACC_hwdata[ACC_hwdata_index]->y;
            accel_sli_in_xyz[2].lw.mslw.sli = pp_ACC_hwdata[ACC_hwdata_index]->z;
            accel_in_data.time_stamp = (bsx_ts_external_t) (pp_ACC_hwdata[ACC_hwdata_index]->timestamp);
            accel_in_data.sensor_id = BSX_INPUT_ID_ACCELERATION;
            ACC_hwdata_index++;
        }

        if(p_align_ind[i] & HAS_MAG)
        {
            mag_has_input = 1;
            mag_sli_in_xyz[0].lw.mslw.sli = pp_MAG_hwdata[MAG_hwdata_index]->x;
            mag_sli_in_xyz[1].lw.mslw.sli = pp_MAG_hwdata[MAG_hwdata_index]->y;
            mag_sli_in_xyz[2].lw.mslw.sli = pp_MAG_hwdata[MAG_hwdata_index]->z;
            mag_in_data.time_stamp = (bsx_ts_external_t) (pp_MAG_hwdata[MAG_hwdata_index]->timestamp);
            mag_in_data.sensor_id = BSX_INPUT_ID_MAGNETICFIELD;
            MAG_hwdata_index++;
        }

        if(p_align_ind[i] & HAS_GYR)
        {
            gyr_has_input = 1;
            ang_sli_in_xyz[0].lw.mslw.sli = pp_GYRO_hwdata[GYRO_hwdata_index]->x;
            ang_sli_in_xyz[1].lw.mslw.sli = pp_GYRO_hwdata[GYRO_hwdata_index]->y;
            ang_sli_in_xyz[2].lw.mslw.sli = pp_GYRO_hwdata[GYRO_hwdata_index]->z;
            ang_in_data.time_stamp = (bsx_ts_external_t) (pp_GYRO_hwdata[GYRO_hwdata_index]->timestamp);
            ang_in_data.sensor_id = BSX_INPUT_ID_ANGULARRATE;
            GYRO_hwdata_index++;
        }

        input_package_index = 0;

        if (data_log){
            memset(&acc_log_data, 0, sizeof(BSX_DATALOG_BUF));
            memset(&gyr_log_data, 0, sizeof(BSX_DATALOG_BUF));
            memset(&mag_log_data, 0, sizeof(BSX_DATALOG_BUF));
        }

        if(acc_has_input){
            library_in_package[input_package_index++] = accel_in_data;
            PINFO("input ACC data: id=%u, D=%d, %d, %d T=%lld",
                    accel_in_data.sensor_id,
                    accel_in_data.content_p[0].lw.mslw.sli,
                    accel_in_data.content_p[1].lw.mslw.sli,
                    accel_in_data.content_p[2].lw.mslw.sli,
                    accel_in_data.time_stamp);

            if(data_log)
            {
                acc_log_data.x = accel_in_data.content_p[0].lw.mslw.sli;
                acc_log_data.y = accel_in_data.content_p[1].lw.mslw.sli;
                acc_log_data.z = accel_in_data.content_p[2].lw.mslw.sli;
                acc_log_data.t = accel_in_data.time_stamp;
            }
        }

        if(mag_has_input){
            library_in_package[input_package_index++] = mag_in_data;
            PINFO("input MAG data: id=%u, D=%d, %d, %d T=%lld",
                    mag_in_data.sensor_id,
                    mag_in_data.content_p[0].lw.mslw.sli,
                    mag_in_data.content_p[1].lw.mslw.sli,
                    mag_in_data.content_p[2].lw.mslw.sli,
                    mag_in_data.time_stamp);

            if(data_log)
            {
                mag_log_data.x = mag_in_data.content_p[0].lw.mslw.sli;
                mag_log_data.y = mag_in_data.content_p[1].lw.mslw.sli;
                mag_log_data.z = mag_in_data.content_p[2].lw.mslw.sli;
                mag_log_data.t = mag_in_data.time_stamp;
            }
        }

        if(gyr_has_input){
            library_in_package[input_package_index++] = ang_in_data;
            PINFO("input GYRO data: id=%u, D=%d, %d, %d T=%lld",
                    ang_in_data.sensor_id,
                    ang_in_data.content_p[0].lw.mslw.sli,
                    ang_in_data.content_p[1].lw.mslw.sli,
                    ang_in_data.content_p[2].lw.mslw.sli,
                    ang_in_data.time_stamp);

            if(data_log)
            {
                gyr_log_data.x = ang_in_data.content_p[0].lw.mslw.sli;
                gyr_log_data.y = ang_in_data.content_p[1].lw.mslw.sli;
                gyr_log_data.z = ang_in_data.content_p[2].lw.mslw.sli;
                gyr_log_data.t = ang_in_data.time_stamp;
            }
        }

        if (data_log)
        {
            sprintf(data_log_buf, "%d, %d, %d, %lld,\t %d, %d, %d, %lld,\t %d, %d, %d, %lld\n",
                    acc_log_data.x, acc_log_data.y, acc_log_data.z, acc_log_data.t,
                    mag_log_data.x, mag_log_data.y, mag_log_data.z, mag_log_data.t,
                    gyr_log_data.x, gyr_log_data.y, gyr_log_data.z, gyr_log_data.t);
            data_log_algo_input(data_log_buf);
        }

        if(!algo_pass)
        {
            if(BSX_INPUT_ID_ACCELERATION == library_in_package[0].sensor_id ||
                    BSX_INPUT_ID_ANGULARRATE == library_in_package[0].sensor_id )
            {
                if(start_AG_gap_check)
                {
                    if((library_in_package[0].time_stamp > last_AG_prevtim) &&
                            (library_in_package[0].time_stamp - last_AG_prevtim < 10000000))
                    {
                        PINFO("abandon obsolete A/G data, timestamp = %lld", library_in_package[0].time_stamp);
                        last_AG_prevtim = library_in_package[0].time_stamp;

                        if(mag_has_input)
                        {
                            if(BSX_INPUT_ID_MAGNETICFIELD == library_in_package[1].sensor_id){
                                last_M_prevtim = library_in_package[1].time_stamp;
                            }else if(BSX_INPUT_ID_MAGNETICFIELD == library_in_package[2].sensor_id){
                                last_M_prevtim = library_in_package[2].time_stamp;
                            }
                        }

                        continue;
                    }else{
                        PINFO("new A/G raw data comes, all gap check removed, tm = %lld, last_AG_tm = %lld", library_in_package[0].time_stamp, last_AG_prevtim);
                        start_AG_gap_check = 0;
                        start_M_gap_check = 0; // M gap check also removed
                    }
                }

                last_AG_prevtim = library_in_package[0].time_stamp;

                if(mag_has_input)
                {
                    if(BSX_INPUT_ID_MAGNETICFIELD == library_in_package[1].sensor_id){
                        last_M_prevtim = library_in_package[1].time_stamp;
                    }else if(BSX_INPUT_ID_MAGNETICFIELD == library_in_package[2].sensor_id){
                        last_M_prevtim = library_in_package[2].time_stamp;
                    }
                }

            }else if(BSX_INPUT_ID_MAGNETICFIELD == library_in_package[0].sensor_id )
            {
                /*if there's A/G input, it should have been at top position, so here means only M input.*/
                if(start_M_gap_check)
                {
                    if((library_in_package[0].time_stamp > last_M_prevtim) &&
                            (library_in_package[0].time_stamp - last_M_prevtim < 45000000))
                    {
                        PINFO("abandon obsolete M data, timestamp = %lld", library_in_package[0].time_stamp);
                        last_M_prevtim = library_in_package[0].time_stamp;
                        /*if there's A/G input, it should have been at top position, so here means no A/G input.
                         * There's no need to update last_AG_prevtim*/
                        continue;
                    }else{
                        PINFO("new M raw data comes, timestamp = %lld, last_M_prevtim = %lld", library_in_package[0].time_stamp, last_M_prevtim);
                        start_M_gap_check = 0;
                    }
                }

                last_M_prevtim = library_in_package[0].time_stamp;
                /*Here means no A/G input. so there's no need to update last_AG_prevtim*/
            }

            nOutput = ARRAY_ELEMENTS(library_out_package);

            bsx_ret = bsx_do_steps(&bsx_instance, BSX_THREAD_MAIN | BSX_THREAD_CALIBRATION, library_in_package,
                    input_package_index, library_out_package, &nOutput);
            PINFO("==== bsx_do_step, nOutput = %u", nOutput);
            if (BSX_OK != bsx_ret)
            {
                if(BSX_I_DOSTEPS_NOOUTPUTSRETURNED == bsx_ret)
                {
                    /** this return value means library are down sampling or dealing with obsolete raw data, so it's normal*/

                }else if(BSX_E_INVALIDSTATE == bsx_ret)
                {
                    /*It means library has closed all sensors and in IDLE state. but now there're still
                     * obsolete raw data not handled.*/
                    bstsensor->shmem_hwcntl.p_list->list_clean();
                    bstsensor->tmplist_hwcntl_acclraw->list_clean();
                    bstsensor->tmplist_hwcntl_magnraw->list_clean();
                    bstsensor->tmplist_hwcntl_gyroraw->list_clean();
                    bstsensor->tmplist_sensord_acclraw->list_clean();
                    bstsensor->tmplist_sensord_gyroraw->list_clean();
                    bstsensor->tmplist_sensord_magnraw->list_clean();
                    bstsensor->shmem_HALdata.p_list->list_clean();

                    start_AG_gap_check = 1;
                    start_M_gap_check = 1;
                    break;
                }else if(BSX_I_DOSTEPS_NOOUTPUTSRETURNABLE == bsx_ret ||
                        BSX_W_DOSTEPS_EXCESSOUTPUTS == bsx_ret)
                {
                    /** acceptable error number */
                    if (log_max < 100)
                    {
                        PWARN("bsx_do_steps fail, ret = %d", bsx_ret);
                        log_max++;
                    }
                }else
                {
                    PERR("bsx_do_steps fail, ret = %d", bsx_ret);
                }

                /** continue to process remianed raw data in list*/
                continue;
            }

            for (j = 0; j < nOutput; j++)
            {
                convert_BSX_output(&library_out_package[j], bstsensor);
            }

        }else
        {
            for (j = 0; j < input_package_index; ++j)
            {
                p_event = (sensors_event_t *) calloc(1, sizeof(sensors_event_t));
                if (NULL == p_event)
                {
                    PWARN("calloc fail");
                    continue;
                }

                p_event->version = sizeof(sensors_event_t);
                p_event->timestamp = library_in_package[j].time_stamp;

                switch(library_in_package[j].sensor_id)
                {
                    case BSX_INPUT_ID_ACCELERATION:
                        p_event->sensor = BSX_SENSOR_ID_ACCELEROMETER;
                        p_event->type = SENSOR_TYPE_ACCELEROMETER;
                        p_event->acceleration.x = library_in_package[j].content_p[0].lw.mslw.sli * CONVERT_ACC;
                        p_event->acceleration.y = library_in_package[j].content_p[1].lw.mslw.sli * CONVERT_ACC;
                        p_event->acceleration.z = library_in_package[j].content_p[2].lw.mslw.sli * CONVERT_ACC;
                        p_event->acceleration.status = 0;
                        break;
                    case BSX_INPUT_ID_MAGNETICFIELD:
                        p_event->sensor = BSX_SENSOR_ID_MAGNETIC_FIELD_UNCALIBRATED;
                        p_event->type = SENSOR_TYPE_MAGNETIC_FIELD_UNCALIBRATED;
                        p_event->uncalibrated_magnetic.x_uncalib = library_in_package[j].content_p[0].lw.mslw.sli * CONVERT_MAG;
                        p_event->uncalibrated_magnetic.y_uncalib = library_in_package[j].content_p[1].lw.mslw.sli * CONVERT_MAG;
                        p_event->uncalibrated_magnetic.z_uncalib = library_in_package[j].content_p[2].lw.mslw.sli * CONVERT_MAG;
                        break;
                    case BSX_INPUT_ID_ANGULARRATE:
                        p_event->sensor = BSX_SENSOR_ID_GYROSCOPE_UNCALIBRATED;
                        p_event->type = SENSOR_TYPE_GYROSCOPE_UNCALIBRATED;
                        p_event->uncalibrated_gyro.x_uncalib = library_in_package[j].content_p[0].lw.mslw.sli * CONVERT_GYRO;
                        p_event->uncalibrated_gyro.y_uncalib = library_in_package[j].content_p[1].lw.mslw.sli * CONVERT_GYRO;
                        p_event->uncalibrated_gyro.z_uncalib = library_in_package[j].content_p[2].lw.mslw.sli * CONVERT_GYRO;
                        break;
                    default:
                        PERR("impossible bsx_distribute_id: %d", library_in_package[j].sensor_id);
                        free(p_event);
                        continue;
                }

                bstsensor->sensord_deliver_event(p_event);
            }
        }
    }

    distory_hwdata(pp_ACC_hwdata, ACC_hwdata_len);
    distory_hwdata(pp_MAG_hwdata, MAG_hwdata_len);
    distory_hwdata(pp_GYRO_hwdata, GYRO_hwdata_len);
    free(p_align_ind);

    return;
}


/**
 * if the current accurary == 3, save calibrate profile in FS.
 */
static void sensord_save_calib_profile()
{
    bsx_return_t bsx_ret;
    int32_t ret;

    if(SENSOR_STATUS_ACCURACY_HIGH == acc_accuarcy_status)
    {
        bsx_ret = bsx_get_state(&bsx_instance, BSX_PROPERTY_SET_ID_CALIBRATOR_ACCELEROMETER,
                                state_string, sizeof(state_string),
                                work_buffer, work_buffer_size,
                                &state_string_size);
        if (BSX_OK != bsx_ret)
        {
            PERR("bsx_get_state fail, ret = %d", bsx_ret);
        }else
        {
            ret = sensord_save_confstr(PROFILE_CALIB_A, state_string, state_string_size);
            if(ret)
            {
                PWARN("save %s fail", PROFILE_CALIB_A);
            }
        }
    }

    if(SENSOR_STATUS_ACCURACY_HIGH == mag_accuarcy_status)
    {
        bsx_ret = bsx_get_state(&bsx_instance, BSX_PROPERTY_SET_ID_CALIBRATOR_MAGNETOMETER,
                                state_string, sizeof(state_string),
                                work_buffer, work_buffer_size,
                                &state_string_size);
        if (BSX_OK != bsx_ret)
        {
            PERR("bsx_get_state fail, ret = %d", bsx_ret);
        }else
        {
            ret = sensord_save_confstr(PROFILE_CALIB_M, state_string, state_string_size);
            if(ret)
            {
                PWARN("save %s fail", PROFILE_CALIB_M);
            }
        }
    }

    if(SENSOR_STATUS_ACCURACY_HIGH == gyr_accuarcy_status)
    {
        bsx_ret = bsx_get_state(&bsx_instance, BSX_PROPERTY_SET_ID_CALIBRATOR_GYROSCOPE,
                                state_string, sizeof(state_string),
                                work_buffer, work_buffer_size,
                                &state_string_size);
        if (BSX_OK != bsx_ret)
        {
            PERR("bsx_get_state fail, ret = %d", bsx_ret);
        }else
        {
            ret = sensord_save_confstr(PROFILE_CALIB_G, state_string, state_string_size);
            if(ret)
            {
                PWARN("save %s fail", PROFILE_CALIB_G);
            }
        }
    }

    return;
}

bsx_return_t sensord_update_subscription(
                        bsx_sensor_configuration_t *const virtual_sensor_config_p,
                        bsx_u32_t *const n_virtual_sensor_config_p,
                        bsx_sensor_configuration_t *const physical_sensor_config_p,
                        bsx_u32_t *const n_physical_sensor_config_p, uint32_t cur_active_cnt)
{

    uint32_t i;
    bsx_return_t bsx_ret = 0;

    if( 0 == cur_active_cnt)
    {
        /*Notice: There's situation in Android that sensord_algo_process() is not invoked yet but
         * sensord_update_subscription() is called firstly. So "this_bstsensor" maybe NULL.
         */
        if(this_bstsensor)
        {
            /*It means library is going to close all sensors and in IDLE state. But now there're still
             * obsolete raw data not handled. So clear them and start gap check to notify thread sensord to flush
             */
            this_bstsensor->shmem_hwcntl.p_list->list_clean();
            this_bstsensor->tmplist_hwcntl_acclraw->list_clean();
            this_bstsensor->tmplist_hwcntl_magnraw->list_clean();
            this_bstsensor->tmplist_hwcntl_gyroraw->list_clean();
            this_bstsensor->tmplist_sensord_acclraw->list_clean();
            this_bstsensor->tmplist_sensord_gyroraw->list_clean();
            this_bstsensor->tmplist_sensord_magnraw->list_clean();
            this_bstsensor->shmem_HALdata.p_list->list_clean();

            start_AG_gap_check = 1;
            start_M_gap_check = 1;
        }

        sensord_save_calib_profile();
    }

    for (i = 0; i < *n_virtual_sensor_config_p; ++i)
    {
        PINFO("update subscription, supplier_id = %u rate = %f", virtual_sensor_config_p[i].sensor_id, virtual_sensor_config_p[i].sample_rate);
    }

    bsx_ret = bsx_update_subscription(&bsx_instance,
            virtual_sensor_config_p, n_virtual_sensor_config_p,
            physical_sensor_config_p, n_physical_sensor_config_p);


    return bsx_ret;
}

uint8_t sensord_resample5to4(int32_t data[3], int64_t *tm,  int32_t pre_data[3], int64_t *pre_tm, uint32_t counter)
{
  uint8_t statusBit;
  int32_t x_in_tmp, y_in_tmp, z_in_tmp;
  int64_t tm_in_tmp;
  uint32_t sampleNumber;
  bool guard1 = false;
  int32_t  x0, y0, z0;
  int32_t  x1, y1, z1;
  int64_t t0;
  int64_t t1;

  x_in_tmp = data[0];
  y_in_tmp = data[1];
  z_in_tmp = data[2];
  tm_in_tmp = tm[0];

  sampleNumber = counter % 5U;
  guard1 = false;

  switch (sampleNumber) {
   case 0U:
    statusBit = 1;
    data[0] = pre_data[0];
    data[1] = pre_data[1];
    data[2] = pre_data[2];
    tm[0] = pre_tm[0];
    break;

   case 1U:
    guard1 = true;
    break;

   case 2U:
    guard1 = true;
    break;

   case 3U:
    guard1 = true;
    break;

   case 4U:
    statusBit = 0;
    break;
  }

  if (guard1)
  {
    statusBit = 1;
    x0 = (pre_data[0] < 0x7FFFFFFD ? pre_data[0] : 0x7FFFFFFD);
    y0 = (pre_data[1] < 0x7FFFFFFD ? pre_data[1] : 0x7FFFFFFD);
    z0 = (pre_data[2] < 0x7FFFFFFD ? pre_data[2] : 0x7FFFFFFD);
    x1 = (data[0] < 0x7FFFFFFD ? data[0] : 0x7FFFFFFD);
    y1 = (data[1] < 0x7FFFFFFD ? data[1] : 0x7FFFFFFD);
    z1 = (data[2] < 0x7FFFFFFD ? data[2] : 0x7FFFFFFD);

    data[0] = (4 - (int32_t)sampleNumber) * ((x0 + 2) >> 2) + (int32_t)sampleNumber * ((x1 + 2) >> 2);
    data[1] = (4 - (int32_t)sampleNumber) * ((y0 + 2) >> 2) + (int32_t)sampleNumber * ((y1 + 2) >> 2);
    data[2] = (4 - (int32_t)sampleNumber) * ((z0 + 2) >> 2) + (int32_t)sampleNumber * ((z1 + 2) >> 2);

    t0 = (pre_tm[0] < 0x7FFFFFFFFFFFFFFD ? pre_tm[0] : 0x7FFFFFFFFFFFFFFD);
    t1 = (tm[0] < 0x7FFFFFFFFFFFFFFD ? tm[0] : 0x7FFFFFFFFFFFFFFD);

    tm[0] = (4LL - sampleNumber) * ((t0 + 2LL) >> 2LL) + sampleNumber * ((t1 +2LL) >> 2LL);
  }

  pre_data[0] = x_in_tmp;
  pre_data[1] = y_in_tmp;
  pre_data[2] = z_in_tmp;
  pre_tm[0] = tm_in_tmp;

  return statusBit;
}


#ifdef __cplusplus
extern "C"
{
#endif

void ladon_assert(int condition, char *file_name, char *function_name, int line_number, char *format_string_p, ...)
{
    if (!condition)
    {
        char message_buffer[1024];
        va_list variable_argument_list_p;

        va_start(variable_argument_list_p, format_string_p);
        vsprintf(message_buffer, format_string_p, variable_argument_list_p);
        va_end(variable_argument_list_p);

        PLADON("Assertion failed in file [%s]\n at function %s on line %d with message:\n\"%s\"",
               file_name, function_name, line_number, message_buffer);
    }
}

void ladon_warning(char *file_name, char *function_name, int line_number, char *format_string_p, ...)
{
    char message_buffer[1024];
    va_list variable_argument_list_p;

    va_start(variable_argument_list_p, format_string_p);
    vsprintf(message_buffer, format_string_p, variable_argument_list_p);
    va_end(variable_argument_list_p);

    PLADON("Warning issued in file [%s]\n at function %s on line %d with message:\n\"%s\"",
           file_name, function_name, line_number, message_buffer);
}

#ifdef __cplusplus
}
#endif

