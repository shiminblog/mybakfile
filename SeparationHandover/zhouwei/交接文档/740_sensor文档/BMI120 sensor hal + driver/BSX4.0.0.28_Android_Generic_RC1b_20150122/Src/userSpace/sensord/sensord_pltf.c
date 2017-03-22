/*!
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
 * @file         sensord_pltf.c
 * @date         "Wed Nov 4 13:08:04 2015 +0800"
 * @commit       "f1de65e"
 *
 * @brief
 *
 * @detail
 *
 */
#include <stdio.h>
#include <unistd.h>
#include <stdint.h>
#include <stdlib.h>
#include <string.h>
#include <stdarg.h>
#include <time.h>
#include <errno.h>
#include <dirent.h>
#include <sys/types.h>
#include <sys/stat.h>
#include <sys/ioctl.h>
#include <fcntl.h>

#include "sensord_def.h"
#include "sensord_cfg.h"
#include "sensord_pltf.h"

#define SENSORD_TRACE_FILE (PATH_DIR_SENSOR_STORAGE "/sensord.log")
#define DATA_IN_FILE (PATH_DIR_SENSOR_STORAGE "/data_in.log")
#define DATA_OUT_FILE_A (PATH_DIR_SENSOR_STORAGE "/data_out_A.log")
#define DATA_OUT_FILE_M (PATH_DIR_SENSOR_STORAGE "/data_out_M.log")
#define DATA_OUT_FILE_G (PATH_DIR_SENSOR_STORAGE "/data_out_G.log")
#define DATA_OUT_FILE_O (PATH_DIR_SENSOR_STORAGE "/data_out_O.log")
#define DATA_OUT_FILE_VG (PATH_DIR_SENSOR_STORAGE "/data_out_VG.log")
#define DATA_OUT_FILE_VLA (PATH_DIR_SENSOR_STORAGE "/data_out_VLA.log")

static FILE *g_fp_trace = NULL;
static FILE *g_dlog_input = NULL;
static FILE *g_fd_log_data_a = NULL;
static FILE *g_fd_log_data_m = NULL;
static FILE *g_fd_log_data_o = NULL;
static FILE *g_fd_log_data_g = NULL;
static FILE *g_fd_log_data_vg = NULL;
static FILE *g_fd_log_data_vla = NULL;

static inline void storage_init()
{
    char *path = NULL;
    int ret = 0;
    struct stat st;

    path = (char *) (PATH_DIR_SENSOR_STORAGE);

    ret = stat(path, &st);
    if (0 == ret)
    {
        if (S_IFDIR == (st.st_mode & S_IFMT))
        {
            /*already exist*/
            ret = chmod(path, 0766);
            if (ret)
            {
                printf("error chmod on %s", path);
            }
        }

        return;
    }

    ret = mkdir(path, 0766);
    if (ret)
    {
        printf("error creating storage dir\n");
    }
    chmod(path, 0766); //notice the "umask" could mask some privilege when mkdir

    return;
}

void sensord_trace_init()
{
    g_fp_trace = fopen(SENSORD_TRACE_FILE, "w");
    if(NULL == g_fp_trace)
    {
        printf("sensord_trace_init: fail to open log file %s! \n", SENSORD_TRACE_FILE);
        g_fp_trace = stdout;
        return;
    }

    chmod(SENSORD_TRACE_FILE, S_IRUSR|S_IWUSR|S_IRGRP|S_IWGRP|S_IROTH|S_IWOTH);

    return;
}

int64_t sensord_get_tmstmp_ns(void)
{

    int64_t ap_time;
    struct timespec ts;

    clock_gettime(CLOCK_BOOTTIME, &ts);
    ap_time = (int64_t) ts.tv_sec * 1000000000 + ts.tv_nsec;

    return ap_time;

}

void trace_log(uint32_t level, const char *fmt, ...)
{
    int ret = 0;
    va_list ap;
#if !defined(UNIT_TEST_ACTIVE)
    char buffer[256] = { 0 };
#endif

    if (0 == trace_to_logcat)
    {
        if (0 == (trace_level & level))
        {
            return;
        }

        va_start(ap, fmt);
        ret = vfprintf(g_fp_trace, fmt, ap);
        va_end(ap);

        // otherwise, data is buffered rather than be wrote to file
        // therefore when stopped by signal, NO data left in file!
        fflush(g_fp_trace);

        if (ret < 0)
        {
            printf("trace_log: fprintf(g_fp_trace, fmt, ap)  fail!!\n");
        }
    }
    else
    {

#if !defined(UNIT_TEST_ACTIVE)
        /**
         * here use android api
         * Let it use Android trace level.
         */
#include<android/log.h>
#define LOG_TAG    "sensord"

        va_start(ap, fmt);
        vsnprintf(buffer, sizeof(buffer) - 1, fmt, ap);
        va_end(ap);

        switch (level)
        {
            case LOG_LEVEL_N:
                __android_log_print(ANDROID_LOG_FATAL, LOG_TAG, "%s", buffer);
                break;
            case LOG_LEVEL_E:
                __android_log_print(ANDROID_LOG_ERROR, LOG_TAG, "%s", buffer);
                break;
            case LOG_LEVEL_W:
                __android_log_print(ANDROID_LOG_WARN, LOG_TAG, "%s", buffer);
                break;
            case LOG_LEVEL_I:
                __android_log_print(ANDROID_LOG_INFO, LOG_TAG, "%s", buffer);
                break;
            case LOG_LEVEL_D:
                __android_log_print(ANDROID_LOG_DEBUG, LOG_TAG, "%s", buffer);
                break;
            case LOG_LEVEL_LADON:
                __android_log_print(ANDROID_LOG_WARN, LOG_TAG, "%s", buffer);
                break;
            default:
                break;
        }

#else

        if(0 == (trace_level & level))
        {
            return;
        }

        va_start(ap, fmt);
        vprintf(fmt, ap);
        va_end(ap);

#endif
    }

    return;
}


void data_log_algo_input(char *info_str)
{
    if (NULL == g_dlog_input)
    {
        g_dlog_input = fopen(DATA_IN_FILE, "w");
        if (NULL == g_dlog_input)
        {
            printf("fail to open file %s! \n", DATA_IN_FILE);
            return;
        }

        chmod(DATA_IN_FILE, S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP | S_IROTH | S_IWOTH);
    }

    fprintf(g_dlog_input, "%s", info_str);

    // otherwise, data is buffered rather than be wrote to file
    // therefore when stopped by signal, NO data left in file!
    fflush(g_dlog_input);

}

void data_log_algo_output_A(char *info_str)
{
    if (NULL == g_fd_log_data_a)
    {
        g_fd_log_data_a = fopen(DATA_OUT_FILE_A, "w");
        if (NULL == g_fd_log_data_a)
        {
            printf("fail to open file %s! \n", DATA_OUT_FILE_A);
            return;
        }

        chmod(DATA_OUT_FILE_A, S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP | S_IROTH | S_IWOTH);
    }

    fprintf(g_fd_log_data_a, "%s", info_str);

    // otherwise, data is buffered rather than be wrote to file
    // therefore when stopped by signal, NO data left in file!
    fflush(g_fd_log_data_a);

}

void data_log_algo_output_M(char *info_str)
{
    if (NULL == g_fd_log_data_m)
    {
        g_fd_log_data_m = fopen(DATA_OUT_FILE_M, "w");
        if (NULL == g_fd_log_data_m)
        {
            printf("fail to open file %s! \n", DATA_OUT_FILE_M);
            return;
        }

        chmod(DATA_OUT_FILE_M, S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP | S_IROTH | S_IWOTH);
    }

    fprintf(g_fd_log_data_m, "%s", info_str);

    // otherwise, data is buffered rather than be wrote to file
    // therefore when stopped by signal, NO data left in file!
    fflush(g_fd_log_data_m);

}

void data_log_algo_output_O(char *info_str)
{
    if (NULL == g_fd_log_data_o)
    {
        g_fd_log_data_o = fopen(DATA_OUT_FILE_O, "w");
        if (NULL == g_fd_log_data_o)
        {
            printf("fail to open file %s! \n", DATA_OUT_FILE_O);
            return;
        }

        chmod(DATA_OUT_FILE_O, S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP | S_IROTH | S_IWOTH);
    }

    fprintf(g_fd_log_data_o, "%s", info_str);

    // otherwise, data is buffered rather than be wrote to file
    // therefore when stopped by signal, NO data left in file!
    fflush(g_fd_log_data_o);

}

void data_log_algo_output_G(char *info_str)
{
    if (NULL == g_fd_log_data_g)
    {
        g_fd_log_data_g = fopen(DATA_OUT_FILE_G, "w");
        if (NULL == g_fd_log_data_g)
        {
            printf("fail to open file %s! \n", DATA_OUT_FILE_G);
            return;
        }

        chmod(DATA_OUT_FILE_G, S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP | S_IROTH | S_IWOTH);
    }

    fprintf(g_fd_log_data_g, "%s", info_str);

    // otherwise, data is buffered rather than be wrote to file
    // therefore when stopped by signal, NO data left in file!
    fflush(g_fd_log_data_g);

}

void data_log_algo_output_VG(char *info_str)
{
    if (NULL == g_fd_log_data_vg)
    {
        g_fd_log_data_vg = fopen(DATA_OUT_FILE_VG, "w");
        if (NULL == g_fd_log_data_vg)
        {
            printf("fail to open file %s! \n", DATA_OUT_FILE_VG);
            return;
        }

        chmod(DATA_OUT_FILE_VG, S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP | S_IROTH | S_IWOTH);
    }

    fprintf(g_fd_log_data_vg, "%s", info_str);

    // otherwise, data is buffered rather than be wrote to file
    // therefore when stopped by signal, NO data left in file!
    fflush(g_fd_log_data_vg);

}
void data_log_algo_output_VLA(char *info_str)
{
    if (NULL == g_fd_log_data_vla)
    {
        g_fd_log_data_vla = fopen(DATA_OUT_FILE_VLA, "w");
        if (NULL == g_fd_log_data_vla)
        {
            printf("fail to open file %s! \n", DATA_OUT_FILE_VLA);
            return;
        }

        chmod(DATA_OUT_FILE_VLA, S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP | S_IROTH | S_IWOTH);
    }

    fprintf(g_fd_log_data_vla, "%s", info_str);

    // otherwise, data is buffered rather than be wrote to file
    // therefore when stopped by signal, NO data left in file!
    fflush(g_fd_log_data_vla);

}

void sensord_pltf_init(void)
{
    storage_init();

    sensord_trace_init();

    return;
}

void sensord_pltf_clearup(void)
{
    fclose(g_fp_trace);

    if (g_dlog_input)
    {
        fclose(g_dlog_input);
    }

    if (g_fd_log_data_a)
    {
        fclose(g_fd_log_data_a);
    }
    if (g_fd_log_data_m)
    {
        fclose(g_fd_log_data_m);
    }
    if (g_fd_log_data_o)
    {
        fclose(g_fd_log_data_o);
    }
    if (g_fd_log_data_g)
    {
        fclose(g_fd_log_data_g);
    }
    if (g_fd_log_data_vg)
    {
        fclose(g_fd_log_data_vg);
    }
    if (g_fd_log_data_vla)
    {
        fclose(g_fd_log_data_vla);
    }
    return;
}

