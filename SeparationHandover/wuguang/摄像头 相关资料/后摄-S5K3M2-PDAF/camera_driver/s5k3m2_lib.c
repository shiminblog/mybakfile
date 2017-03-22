/*============================================================================

  Copyright (c) 2014 Qualcomm Technologies, Inc. All Rights Reserved.
  Qualcomm Technologies Proprietary and Confidential.

============================================================================*/
#include <stdio.h>
#include "sensor_lib.h"

#define SENSOR_MODEL_NO_S5K3M2 "s5k3m2_captur"
#define S5K3M2_LOAD_CHROMATIX(n) \
  "libchromatix_"SENSOR_MODEL_NO_S5K3M2"_"#n".so"
  
#define SNAPSHOT_PARAMS  1
#define PREVIEW_PARAMS   1

static sensor_lib_t sensor_lib_ptr;

static struct msm_sensor_power_setting power_setting[] = {
  /* control reset pin high */
  {
    .seq_type = SENSOR_GPIO,
    .seq_val = SENSOR_GPIO_RESET,
    .config_val = GPIO_OUT_LOW,
    .delay = 1,
  },
#if 0
  {
    .seq_type = SENSOR_GPIO,
    .seq_val = SENSOR_GPIO_VDIG,
    .config_val = GPIO_OUT_HIGH,
    .delay = 5,
  },

  {
    .seq_type = SENSOR_GPIO,
    .seq_val = SENSOR_GPIO_VANA,
    .config_val = GPIO_OUT_HIGH,
    .delay = 5,
  },
#endif

/* open Vio voltage via vreg */
  {
    .seq_type = SENSOR_VREG,
    .seq_val = CAM_VIO,
    .config_val = 0,
    .delay = 1,
  },

#if 1   //add by wuyixiang
/* open Vaf voltage via vreg */
  {
    .seq_type = SENSOR_VREG,
    .seq_val = CAM_VAF,
    .config_val = 0,
    .delay = 5,
  },
#endif

/* control reset pin */
  {
    .seq_type = SENSOR_GPIO,
    .seq_val = SENSOR_GPIO_RESET,
    .config_val = GPIO_OUT_HIGH,
    .delay = 5, 
  },

  {
    .seq_type = SENSOR_CLK,
    .seq_val = SENSOR_CAM_MCLK,
    .config_val = 23880000,//Eric  15-0105
    .delay = 10,
  },
  {
    .seq_type = SENSOR_I2C_MUX,
    .seq_val = 0,
    .config_val = 0,
    .delay = 0,
  },
};

static struct msm_sensor_power_setting power_down_setting[] = {
  {
    .seq_type = SENSOR_I2C_MUX,
    .seq_val = 0,
    .config_val = 0,
    .delay = 0,
  },
  {
    .seq_type = SENSOR_CLK,
    .seq_val = SENSOR_CAM_MCLK,
    .config_val = 0,//Eric  1107
    .delay = 1,
  },

/* control reset pin */
  {
    .seq_type = SENSOR_GPIO,
    .seq_val = SENSOR_GPIO_RESET,
    .config_val = GPIO_OUT_LOW,
    .delay = 5,
  },
  
#if 1   //add by wuyixiang
/* close Vaf voltage via vreg */
  {
    .seq_type = SENSOR_VREG,
    .seq_val = CAM_VAF,
    .config_val = 0,
    .delay = 5,
  },
#endif
#if 0
  {
    .seq_type = SENSOR_GPIO,
    .seq_val = SENSOR_GPIO_VDIG,
    .config_val = GPIO_OUT_LOW,
    .delay = 5,
  },

  {
    .seq_type = SENSOR_GPIO,
    .seq_val = SENSOR_GPIO_VANA,
    .config_val = GPIO_OUT_LOW,
    .delay = 5,
  },
#endif

/* close Vio voltage via vreg */
  {
    .seq_type = SENSOR_VREG,
    .seq_val = CAM_VIO,
    .config_val = 0,
    .delay = 1,
  },


};


static struct msm_camera_sensor_slave_info sensor_slave_info = {
  /* Camera slot where this camera is mounted */
  .camera_id = CAMERA_0,
  /* sensor slave address */
//  .slave_addr = 0x20,
  .slave_addr = 0x5A,
  /* sensor address type */
  .addr_type = MSM_CAMERA_I2C_WORD_ADDR,
  /* sensor id info*/
  .sensor_id_info = {
    /* sensor id register address */
    .sensor_id_reg_addr = 0x00,
    /* sensor id */
    .sensor_id = 0x30d2,
  },
  /* power up / down setting */
  .power_setting_array = {
    .power_setting = power_setting,
   .power_down_setting = power_down_setting,
    .size = ARRAY_SIZE(power_setting),
    .size_down = ARRAY_SIZE(power_down_setting),
  },
  .is_flash_supported = SENSOR_FLASH_SUPPORTED,
};

static struct msm_sensor_init_params sensor_init_params = {
  .modes_supported = CAMERA_MODE_2D_B  ,
  .position = 0,
  .sensor_mount_angle = 90,
};

static sensor_output_t sensor_output = {
  .output_format = SENSOR_BAYER,
  .connection_mode = SENSOR_MIPI_CSI,
  .raw_output = SENSOR_10_BIT_DIRECT,
};

static struct msm_sensor_output_reg_addr_t output_reg_addr = {
  .x_output = 0x034C,
  .y_output = 0x034E,
  .line_length_pclk = 0x0342,
  .frame_length_lines = 0x0340,
};

static struct msm_sensor_exp_gain_info_t exp_gain_info = {
  .coarse_int_time_addr = 0x0202,
  .global_gain_addr = 0x0204,
  .vert_offset = 8,
};

static sensor_aec_data_t aec_info = {
  .max_gain = 16.0,
  .max_linecount = 57888,/*preview frame_length_lines * 24 */
};

static sensor_lens_info_t default_lens_info = {
  .focal_length = 4.6,
  .pix_size = 1.4,
  .f_number = 2.65,
  .total_f_dist = 1.97,
  .hor_view_angle = 54.8,
  .ver_view_angle = 42.5,
};


#ifndef VFE_40
static struct csi_lane_params_t csi_lane_params = {
  .csi_lane_assign = 0xe4,
  .csi_lane_mask = 0xf,
  .csi_if = 1,
  .csid_core = {0},
  .csi_phy_sel = 0,
};
#else
//CSI-PHY config
static struct csi_lane_params_t csi_lane_params = {
  .csi_lane_assign = 0x4320,
  .csi_lane_mask = 0x1F,
  .csi_if = 1,
  .csid_core = {0},
  .csi_phy_sel = 0,
};
#endif

static struct msm_camera_i2c_reg_array init_reg_array0[] = {
	{0x6028, 0x4000},
	{0x6214, 0x7971},
	{0x6218, 0x0100},
	{0x6028, 0x2000},
	{0x602A, 0x448C},
	{0x6F12, 0x0000},
	{0x6F12, 0x0000},
	{0x6F12, 0x0448},
	{0x6F12, 0x0349},
	{0x6F12, 0x0160},
	{0x6F12, 0xC26A},
	{0x6F12, 0x511A},
	{0x6F12, 0x8180},
	{0x6F12, 0x00F0},
	{0x6F12, 0x2CB8},
	{0x6F12, 0x2000},
	{0x6F12, 0x4538},
	{0x6F12, 0x2000},
	{0x6F12, 0x1FA0},
	{0x6F12, 0x0000},
	{0x6F12, 0x0000},
	{0x6F12, 0x0000},
	{0x6F12, 0x0000},
	{0x6F12, 0x2DE9},
	{0x6F12, 0xF041},
	{0x6F12, 0x0546},
	{0x6F12, 0x1348},
	{0x6F12, 0x134E},
	{0x6F12, 0x018A},
	{0x6F12, 0x4069},
	{0x6F12, 0x06F1},
	{0x6F12, 0x2007},
	{0x6F12, 0x4143},
	{0x6F12, 0x4FEA},
	{0x6F12, 0x1138},
	{0x6F12, 0x0024},
	{0x6F12, 0x06EB},
	{0x6F12, 0xC402},
	{0x6F12, 0x0423},
	{0x6F12, 0x3946},
	{0x6F12, 0x4046},
	{0x6F12, 0x00F0},
	{0x6F12, 0x1EF8},
	{0x6F12, 0x25F8},
	{0x6F12, 0x1400},
	{0x6F12, 0x641C},
	{0x6F12, 0x042C},
	{0x6F12, 0xF3DB},
	{0x6F12, 0x0A48},
	{0x6F12, 0x2988},
	{0x6F12, 0x0180},
	{0x6F12, 0x6988},
	{0x6F12, 0x4180},
	{0x6F12, 0xA988},
	{0x6F12, 0x8180},
	{0x6F12, 0xE988},
	{0x6F12, 0xC180},
	{0x6F12, 0xBDE8},
	{0x6F12, 0xF081},
	{0x6F12, 0x0022},
	{0x6F12, 0xAFF2},
	{0x6F12, 0x4B01},
	{0x6F12, 0x0448},
	{0x6F12, 0x00F0},
	{0x6F12, 0x0DB8},
	{0x6F12, 0x2000},
	{0x6F12, 0x34D0},
	{0x6F12, 0x2000},
	{0x6F12, 0x7900},
	{0x6F12, 0x4000},
	{0x6F12, 0xD22E},
	{0x6F12, 0x0000},
	{0x6F12, 0x2941},
	{0x6F12, 0x40F2},
	{0x6F12, 0xFD7C},
	{0x6F12, 0xC0F2},
	{0x6F12, 0x000C},
	{0x6F12, 0x6047},
	{0x6F12, 0x4DF2},
	{0x6F12, 0x474C},
	{0x6F12, 0xC0F2},
	{0x6F12, 0x000C},
	{0x6F12, 0x6047},
	{0x6F12, 0x0000},
	{0x6F12, 0x0000},
	{0x6F12, 0x0000},
	{0x6F12, 0x0000},
	{0x6F12, 0x30D2},
	{0x6F12, 0x029C},
	{0x6F12, 0x0000},
	{0x6F12, 0x0001},
	{0x602A, 0x7900},
	{0x6F12, 0x4000},
	{0x6F12, 0x3000},
	{0x6F12, 0x2000},
	{0x6F12, 0x1000},
	{0x6F12, 0x4000},
	{0x6F12, 0x3000},
	{0x6F12, 0x2000},
	{0x6F12, 0x1000},
	{0x6F12, 0x4000},
	{0x6F12, 0x3000},
	{0x6F12, 0x2000},
	{0x6F12, 0x1000},
	{0x6F12, 0x4000},
	{0x6F12, 0x3000},
	{0x6F12, 0x2000},
	{0x6F12, 0x1000},
	{0x6F12, 0x0100},
	{0x6F12, 0x0200},
	{0x6F12, 0x0400},
	{0x6F12, 0x0800},
	{0x602A, 0x43F0},
	{0x6F12, 0x0128},
	{0x6F12, 0x00DC},
	{0x6F12, 0x5590},
	{0x6F12, 0x3644},
	{0x602A, 0x1B50},
	{0x6F12, 0x0000},
	{0x602A, 0x1B54},
	{0x6F12, 0x0000},
	{0x602A, 0x1B64},
	{0x6F12, 0x0800},
	{0x602A, 0x1926},
	{0x6F12, 0x0011},
	{0x602A, 0x14FA},
	{0x6F12, 0x0F00},
	{0x602A, 0x4472},
	{0x6F12, 0x0102},
	{0x6028, 0x4000},
	{0x0B04, 0x0101},
	{0x3B22, 0x1110},
	{0xF42E, 0x200C},
	{0xF49E, 0x004C},
	{0xF4A6, 0x00F0},
	{0x3AFA, 0xFBB8},
	{0xF49C, 0x0000},
	{0xF496, 0x0000},
	{0xF476, 0x0040},
	{0x3AAA, 0x0205},
	{0x3AFE, 0x07DF},
	{0xF47A, 0x001B},
	{0xF462, 0x0003},
	{0xF460, 0x0020},
	{0x3B06, 0x000E},
	{0x3AD0, 0x0080},
	{0x3B02, 0x0020},
	{0xF468, 0x0001},
	{0xF494, 0x000E},
	{0xF40C, 0x2180},
	{0x3870, 0x004C},
	{0x3876, 0x0011},
	{0x3366, 0x0128},
	{0x3852, 0x00EA},
	{0x623E, 0x0004},
	{0x3B5C, 0x0006},

};

static struct msm_camera_i2c_reg_array res0_reg_array[] = {
	 //ExtClk :24MHz            
	 //Vt_pix_clk :440MHz       
	 //MIPI_output_clk :1008Mbps
	 //Crop_Width :4216px       
	 //Crop_Height :3128px      
	 //Output_Width :4208px     
	 //Output_Height :3120px    
	 //Frame rate :27.51fps     
	 //Output format :Raw10     
	 //*Pedestal :0             
	 //*Mapped BPC :On          
	 //*Dynamic BPC :Off        
	 //*Internal LSC :On        
	 //H-size :5008px           
	 //H-blank :800px           
	 //V-size :3194line         
	 //V-blank :74line          
	 //Lane :4lane              
	  
  {0x6028, 0x2000},	
  {0x602A, 0x14F0},	
  {0x6F12, 0x0000},	 // 0
  {0x6F12, 0x0000},	 // 0
  {0x6028, 0x4000},	
  {0x0344, 0x0004},	 // 4
  {0x0346, 0x0004},	 // 4
  {0x0348, 0x107B},	 // 4219
  {0x034A, 0x0C3B},	 // 3131
  {0x034C, 0x1070},	 // 4208
  {0x034E, 0x0C30},	 // 3120
  {0x0900, 0x0111},	
  {0x0380, 0x0001},	
  {0x0382, 0x0001},	
  {0x0384, 0x0001},	
  {0x0386, 0x0001},	
  {0x0400, 0x0002},	
  {0x0404, 0x0010},	
  {0x0114, 0x0300},	
  {0x0110, 0x0002},	
  {0x112C, 0x0000},	
  {0x112E, 0x0000},	
  {0x0136, 0x1800},	 // 24MHz
  {0x0304, 0x0006},	 // 6
  {0x0306, 0x006E},	 // 110
  {0x0302, 0x0001},	 // 1
  {0x0300, 0x0004},	 // 4
  {0x030C, 0x0004},	 // 4
  {0x030E, 0x0054},	 // 84
  {0x030A, 0x0001},	 // 1
  {0x0308, 0x0008},	 // 8
  {0x0342, 0x1390},	 // 5008
  {0x0340, 0x0C7A},	 // 3194
  {0x0202, 0x0200},	 // 512
  {0x0200, 0x0400},	 // 1024
  {0x0B04, 0x0101},	
  {0x0B08, 0x0000},	
  {0x0B00, 0x0180},	
  {0x3B3C, 0x0107},	
  {0x3B34, 0x3030},	
  {0x3B36, 0x3030},	
  {0x3B38, 0x3030},	
  {0x3B3A, 0x3030},	
  {0x306A, 0x0068},	
};

static struct msm_camera_i2c_reg_array res1_reg_array[] = {
   //ExtClk :24MHz
   //Vt_pix_clk :440MHz
   //MIPI_output_clk :600Mbps
   //Crop_Width :4216px
   //Crop_Height :3136px
   //Output_Width :2104px
   //Output_Height :1560px
   //Frame rate :54.5fps
   //Output format :Raw10
   //*Pedestal :0
   //*Mapped BPC :On
   //*Dynamic BPC :Off
   //*Internal LSC :On
   //H-size :5008px
   //H-blank :2904px
   //V-size :2940line
   //V-blank :52line
   //Lane :4lane

	{0x6028, 0x2000},	
	{0x602A, 0x14F0},	
	{0x6F12, 0x0000},	 // 0
	{0x6F12, 0x0000},	 // 0
	{0x6028, 0x4000},	
	{0x0344, 0x0004},	 // 4
	{0x0346, 0x0000},	 // 0
	{0x0348, 0x107B},	 // 4219
	{0x034A, 0x0C3F},	 // 3135
	{0x034C, 0x0838},	 // 2104
	{0x034E, 0x0618},	 // 1560
	{0x0900, 0x0112},	
	{0x0380, 0x0001},	
	{0x0382, 0x0001},	
	{0x0384, 0x0001},	
	{0x0386, 0x0003},	
	{0x0400, 0x0001},	
	{0x0404, 0x0020},	
	{0x0114, 0x0300},	
	{0x0110, 0x0002},	
	{0x112C, 0x0000},	
	{0x112E, 0x0000},	
	{0x0136, 0x1800},	 // 24MHz
	{0x0304, 0x0006},	 // 6
	{0x0306, 0x006E},	 // 110
	{0x0302, 0x0001},	 // 1
	{0x0300, 0x0004},	 // 4
	{0x030C, 0x0004},	 // 4
	{0x030E, 0x0032},	 // 50
	{0x030A, 0x0001},	 // 1
	{0x0308, 0x0008},	 // 8
	{0x0342, 0x1390},	 // 5008
	{0x0340, 0x0B7C},	 // 2940
	{0x0202, 0x0200},	 // 512
	{0x0200, 0x0400},	 // 1024
	{0x0B04, 0x0101},	
	{0x0B08, 0x0000},	
	{0x0B00, 0x0180},	
	{0x3B3C, 0x0107},	
	{0x3B34, 0x3030},	
	{0x3B36, 0x3030},	
	{0x3B38, 0x3030},	
	{0x3B3A, 0x3030},	
	{0x306A, 0x0068},	
};

static struct msm_camera_i2c_reg_setting init_reg_setting[] = {
  {
    .reg_setting = init_reg_array0,
    .size = ARRAY_SIZE(init_reg_array0),
    .addr_type = MSM_CAMERA_I2C_WORD_ADDR,
    .data_type = MSM_CAMERA_I2C_WORD_DATA,
    .delay = 0,
  },
};

static struct sensor_lib_reg_settings_array init_settings_array = {
  .reg_settings = init_reg_setting,
  .size =ARRAY_SIZE(init_reg_setting),
};

static struct msm_camera_i2c_reg_array start_reg_array[] = {
  {0x0100, 0x01},
};

static  struct msm_camera_i2c_reg_setting start_settings = {
  .reg_setting = start_reg_array,
  .size = ARRAY_SIZE(start_reg_array),
  .addr_type = MSM_CAMERA_I2C_WORD_ADDR,
  .data_type = MSM_CAMERA_I2C_BYTE_DATA,
  .delay = 0,
};

static struct msm_camera_i2c_reg_array stop_reg_array[] = {
  {0x0100, 0x00},
};

static struct msm_camera_i2c_reg_setting stop_settings = {
  .reg_setting = stop_reg_array,
  .size = ARRAY_SIZE(stop_reg_array),
  .addr_type = MSM_CAMERA_I2C_WORD_ADDR,
  .data_type = MSM_CAMERA_I2C_BYTE_DATA,
  .delay = 0,
};

static struct msm_camera_i2c_reg_array groupon_reg_array[] = {
  {0x0104, 0x01},
};

static struct msm_camera_i2c_reg_setting groupon_settings = {
  .reg_setting = groupon_reg_array,
  .size = ARRAY_SIZE(groupon_reg_array),
  .addr_type = MSM_CAMERA_I2C_WORD_ADDR,
  .data_type = MSM_CAMERA_I2C_BYTE_DATA,
  .delay = 0,
};

static struct msm_camera_i2c_reg_array groupoff_reg_array[] = {
  {0x0104, 0x00},
};

static struct msm_camera_i2c_reg_setting groupoff_settings = {
  .reg_setting = groupoff_reg_array,
  .size = ARRAY_SIZE(groupoff_reg_array),
  .addr_type = MSM_CAMERA_I2C_WORD_ADDR,
  .data_type = MSM_CAMERA_I2C_BYTE_DATA,
  .delay = 0,
};

static struct msm_camera_csid_vc_cfg s5k3m2_cid_cfg[] = {
  {0, CSI_RAW10, CSI_DECODE_10BIT},
  {1, CSI_EMBED_DATA, CSI_DECODE_8BIT},
};

static struct msm_camera_csi2_params s5k3m2_csi_params = {
  .csid_params = {
    .lane_cnt = 4,
    .lut_params = {
      .num_cid = ARRAY_SIZE(s5k3m2_cid_cfg),
      .vc_cfg = {
         &s5k3m2_cid_cfg[0],
         &s5k3m2_cid_cfg[1],
      },
    },
  },
  .csiphy_params = {
    .lane_cnt = 4,
    .settle_cnt = 0x14,
  },
};

static struct msm_camera_csi2_params *csi_params[] = {
  &s5k3m2_csi_params, /* RES 0*/
  &s5k3m2_csi_params, /* RES 1*/
  &s5k3m2_csi_params, /* RES 2*/
  &s5k3m2_csi_params, /* RES 3*/
  &s5k3m2_csi_params, /* RES 4*/
};

static struct sensor_lib_csi_params_array csi_params_array = {
  .csi2_params = &csi_params[0],
  .size = ARRAY_SIZE(csi_params),
};

static struct sensor_pix_fmt_info_t s5k3m2_pix_fmt0_fourcc[] = {
  //{ V4L2_PIX_FMT_SRGGB10 },
  //{V4L2_PIX_FMT_SBGGR10},
  {V4L2_PIX_FMT_SGRBG10},
  //{V4L2_PIX_FMT_SGBRG10},
};

static struct sensor_pix_fmt_info_t s5k3m2_pix_fmt1_fourcc[] = {
  { MSM_V4L2_PIX_FMT_META },
};

static sensor_stream_info_t s5k3m2_stream_info[] = {
  {1, &s5k3m2_cid_cfg[0], s5k3m2_pix_fmt0_fourcc},
  {1, &s5k3m2_cid_cfg[1], s5k3m2_pix_fmt1_fourcc},
};

static sensor_stream_info_array_t s5k3m2_stream_info_array = {
  .sensor_stream_info = s5k3m2_stream_info,
  .size = ARRAY_SIZE(s5k3m2_stream_info),
};

static struct msm_camera_i2c_reg_setting res_settings[] = {
#if SNAPSHOT_PARAMS
  {
    .reg_setting = res0_reg_array,
    .size = ARRAY_SIZE(res0_reg_array),
    .addr_type = MSM_CAMERA_I2C_WORD_ADDR,
    .data_type = MSM_CAMERA_I2C_WORD_DATA,
    .delay = 0,
  },
#endif
#if PREVIEW_PARAMS
  {
    .reg_setting = res1_reg_array,
    .size = ARRAY_SIZE(res1_reg_array),
    .addr_type = MSM_CAMERA_I2C_WORD_ADDR,
    .data_type = MSM_CAMERA_I2C_WORD_DATA,
    .delay = 10,
  },
#endif
};

static struct sensor_lib_reg_settings_array res_settings_array = {
  .reg_settings = res_settings,
  .size = ARRAY_SIZE(res_settings),
};

static struct sensor_crop_parms_t crop_params[] = {
  {0, 0, 0, 0}, /* RES 0 */
  {0, 0, 0, 0}, /* RES 1 */
  {0, 0, 0, 0}, /* RES 2 */
  {0, 0, 0, 0}, /* RES 3 */
  {0, 0, 0, 0}, /* RES 4 */
};

static struct sensor_lib_crop_params_array crop_params_array = {
  .crop_params = crop_params,
  .size = ARRAY_SIZE(crop_params),
};

static struct sensor_lib_out_info_t sensor_out_info[] = {
#if SNAPSHOT_PARAMS
  {/* 25 fps full size settings */
	.x_output = 4208,
	 .y_output = 3120,
	 .line_length_pclk = 5008,	
	 .frame_length_lines = 3194,  
	 .vt_pixel_clk = 440000000, 
	 .op_pixel_clk = 403200000,       
	 .binning_factor = 1,
	 .max_fps = 27.5, //36.0
	 .min_fps = 7.5,
	 .mode = SENSOR_DEFAULT_MODE,
  },
#endif
#if PREVIEW_PARAMS
  {/* 30 fps qtr size settings */
    .x_output = 2104,
    .y_output = 1560,
    .line_length_pclk = 5008,  
    .frame_length_lines = 2940,  
    .vt_pixel_clk = 440000000,
    .op_pixel_clk = 240000000, 
    .binning_factor = 1,
    .max_fps = 30.0, 
    .min_fps = 7.5,
    .mode = SENSOR_DEFAULT_MODE,
  },
#endif
};

static struct sensor_lib_out_info_array out_info_array = {
  .out_info = sensor_out_info,
  .size = ARRAY_SIZE(sensor_out_info),
};

static sensor_res_cfg_type_t s5k3m2_res_cfg[] = {
  SENSOR_SET_STOP_STREAM,
  SENSOR_SET_NEW_RESOLUTION, /* set stream config */
  SENSOR_SET_CSIPHY_CFG,
  SENSOR_SET_CSID_CFG,
  SENSOR_LOAD_CHROMATIX, /* set chromatix prt */
  SENSOR_SEND_EVENT, /* send event */
  SENSOR_SET_START_STREAM,
};

static struct sensor_res_cfg_table_t s5k3m2_res_table = {
  .res_cfg_type = s5k3m2_res_cfg,
  .size = ARRAY_SIZE(s5k3m2_res_cfg),
};

static struct sensor_lib_chromatix_t s5k3m2_chromatix[] = {
#if SNAPSHOT_PARAMS
  {
    .common_chromatix = S5K3M2_LOAD_CHROMATIX(common),
    .camera_preview_chromatix = S5K3M2_LOAD_CHROMATIX(snapshot), /* RES0 */
    .camera_snapshot_chromatix = S5K3M2_LOAD_CHROMATIX(snapshot), /* RES0 */
    .camcorder_chromatix = S5K3M2_LOAD_CHROMATIX(default_video), /* RES0 */
    .liveshot_chromatix = S5K3M2_LOAD_CHROMATIX(liveshot), /* RES0 */
  },
#endif
#if PREVIEW_PARAMS
  {
    .common_chromatix = S5K3M2_LOAD_CHROMATIX(common),
    .camera_preview_chromatix = S5K3M2_LOAD_CHROMATIX(preview), /* RES1 */
    .camera_snapshot_chromatix = S5K3M2_LOAD_CHROMATIX(preview), /* RES1 */
    .camcorder_chromatix = S5K3M2_LOAD_CHROMATIX(default_video), /* RES1 */
    .liveshot_chromatix = S5K3M2_LOAD_CHROMATIX(liveshot), /* RES1 */
  },
#endif

};

static struct sensor_lib_chromatix_array s5k3m2_lib_chromatix_array = {
  .sensor_lib_chromatix = s5k3m2_chromatix,
  .size = ARRAY_SIZE(s5k3m2_chromatix),
};

/*===========================================================================
 * FUNCTION    - s5k3m2_real_to_register_gain -
 *
 * DESCRIPTION:
 *==========================================================================*/
static uint16_t s5k3m2_real_to_register_gain(float gain)
{
	uint16_t reg_gain;
	if (gain < 1.0)
	  gain = 1.0;
	if (gain > 16.0)
	  gain = 16.0;
	reg_gain = (uint16_t)(gain * 32.0);
	return reg_gain;
}

/*===========================================================================
 * FUNCTION    - s5k3m2_register_to_real_gain -
 *
 * DESCRIPTION:
 *==========================================================================*/
static float s5k3m2_register_to_real_gain(uint16_t reg_gain)
{
	float gain;
	if (reg_gain > 0x0200)
	  reg_gain = 0x0200;
	gain = (float) reg_gain / 32.0;
	return gain;
}

/*===========================================================================
 * FUNCTION    - s5k3m2_calculate_exposure -
 *
 * DESCRIPTION:
 *==========================================================================*/
static int32_t s5k3m2_calculate_exposure(float real_gain,
  uint16_t line_count, sensor_exposure_info_t *exp_info)
{
  if (!exp_info) {
    return -1;
  }
  exp_info->reg_gain = s5k3m2_real_to_register_gain(real_gain);
  exp_info->sensor_real_gain = s5k3m2_register_to_real_gain(exp_info->reg_gain);
  exp_info->digital_gain = real_gain / exp_info->sensor_real_gain;
  exp_info->line_count = line_count;
  exp_info->sensor_digital_gain = 0x1;
  return 0;
}

/*===========================================================================
 * FUNCTION    - s5k3m2_fill_exposure_array -
 *
 * DESCRIPTION:
 *==========================================================================*/
static int32_t s5k3m2_fill_exposure_array(uint16_t gain,
  uint32_t line, uint32_t fl_lines, int32_t luma_avg, uint32_t fgain,
  struct msm_camera_i2c_reg_setting *reg_setting)
{
  int32_t rc = 0;
  uint16_t reg_count = 0;
  uint16_t i = 0;

  if (!reg_setting) {
    return -1;
  }

  for (i = 0; i < sensor_lib_ptr.groupon_settings->size; i++) {
    reg_setting->reg_setting[reg_count].reg_addr =
      sensor_lib_ptr.groupon_settings->reg_setting[i].reg_addr;
    reg_setting->reg_setting[reg_count].reg_data =
      sensor_lib_ptr.groupon_settings->reg_setting[i].reg_data;
    reg_count = reg_count + 1;
  }

  reg_setting->reg_setting[reg_count].reg_addr =
    sensor_lib_ptr.output_reg_addr->frame_length_lines;
  reg_setting->reg_setting[reg_count].reg_data = (fl_lines & 0xFF00) >> 8;
  reg_count++;

  reg_setting->reg_setting[reg_count].reg_addr =
    sensor_lib_ptr.output_reg_addr->frame_length_lines + 1;
  reg_setting->reg_setting[reg_count].reg_data = (fl_lines & 0xFF);
  reg_count++;

  reg_setting->reg_setting[reg_count].reg_addr =
    sensor_lib_ptr.exp_gain_info->coarse_int_time_addr;
  reg_setting->reg_setting[reg_count].reg_data = (line & 0xFF00) >> 8;
  reg_count++;

  reg_setting->reg_setting[reg_count].reg_addr =
    sensor_lib_ptr.exp_gain_info->coarse_int_time_addr + 1;
  reg_setting->reg_setting[reg_count].reg_data = (line & 0xFF);
  reg_count++;

  reg_setting->reg_setting[reg_count].reg_addr =
    sensor_lib_ptr.exp_gain_info->global_gain_addr;
  reg_setting->reg_setting[reg_count].reg_data = (gain & 0xFF00) >> 8;
  reg_count++;

  reg_setting->reg_setting[reg_count].reg_addr =
    sensor_lib_ptr.exp_gain_info->global_gain_addr + 1;
  reg_setting->reg_setting[reg_count].reg_data = (gain & 0xFF);
  reg_count++;

  for (i = 0; i < sensor_lib_ptr.groupoff_settings->size; i++) {
    reg_setting->reg_setting[reg_count].reg_addr =
      sensor_lib_ptr.groupoff_settings->reg_setting[i].reg_addr;
    reg_setting->reg_setting[reg_count].reg_data =
      sensor_lib_ptr.groupoff_settings->reg_setting[i].reg_data;
    reg_count = reg_count + 1;
  }

  reg_setting->size = reg_count;
  reg_setting->addr_type = MSM_CAMERA_I2C_WORD_ADDR;
  reg_setting->data_type = MSM_CAMERA_I2C_BYTE_DATA;
  reg_setting->delay = 0;

  return rc;
}

static sensor_exposure_table_t s5k3m2_expsoure_tbl = {
  .sensor_calculate_exposure = s5k3m2_calculate_exposure,
  .sensor_fill_exposure_array = s5k3m2_fill_exposure_array,
};

static sensor_lib_t sensor_lib_ptr = {
  /* sensor slave info */
  .sensor_slave_info = &sensor_slave_info,
  /* sensor init params */
  .sensor_init_params = &sensor_init_params,
  /* sensor actuator name */
//Add-BEGIN by T2M-WU YiXiang bug#1111194 add for VCM 18/12/2015
  .actuator_name = "ak7348_captur",
//ENG by T2M-WU YiXiang
  /* sensor output settings */
  .sensor_output = &sensor_output,
  /* sensor output register address */
  .output_reg_addr = &output_reg_addr,
  /* sensor exposure gain register address */
  .exp_gain_info = &exp_gain_info,
  /* sensor aec info */
  .aec_info = &aec_info,
  /* sensor snapshot exposure wait frames info */
  .snapshot_exp_wait_frames = 1,
  /* number of frames to skip after start stream */
  .sensor_num_frame_skip = 1,
  /* number of frames to skip after start HDR stream */
  .sensor_num_HDR_frame_skip = 1,
  /* sensor pipeline immediate delay */
  .sensor_max_pipeline_frame_delay = 2,
  /* sensor exposure table size */
  .exposure_table_size = 18,
  /* sensor lens info */
  .default_lens_info = &default_lens_info,
  /* csi lane params */
  .csi_lane_params = &csi_lane_params,
  /* csi cid params */
  .csi_cid_params = s5k3m2_cid_cfg,
  /* csi csid params array size */
  .csi_cid_params_size = ARRAY_SIZE(s5k3m2_cid_cfg),
  /* init settings */
  .init_settings_array = &init_settings_array,
  /* start settings */
  .start_settings = &start_settings,
  /* stop settings */
  .stop_settings = &stop_settings,
  /* group on settings */
  .groupon_settings = &groupon_settings,
  /* group off settings */
  .groupoff_settings = &groupoff_settings,
  /* resolution cfg table */
  .sensor_res_cfg_table = &s5k3m2_res_table,
  /* res settings */
  .res_settings_array = &res_settings_array,
  /* out info array */
  .out_info_array = &out_info_array,
  /* crop params array */
  .crop_params_array = &crop_params_array,
  /* csi params array */
  .csi_params_array = &csi_params_array,
  /* sensor port info array */
  .sensor_stream_info_array = &s5k3m2_stream_info_array,
  /* exposure funtion table */
  .exposure_func_table = &s5k3m2_expsoure_tbl,
  /* chromatix array */
  .chromatix_array = &s5k3m2_lib_chromatix_array,
  /* sensor pipeline immediate delay */
  .sensor_max_immediate_frame_delay = 2,
};

/*===========================================================================
 * FUNCTION    - s5k3m2_captur_open_lib -
 *
 * DESCRIPTION:
 *==========================================================================*/
void *s5k3m2_captur_open_lib(void)
{
  return &sensor_lib_ptr;
}
