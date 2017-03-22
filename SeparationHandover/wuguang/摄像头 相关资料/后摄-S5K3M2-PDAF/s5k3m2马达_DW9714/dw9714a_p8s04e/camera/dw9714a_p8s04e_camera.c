/*============================================================================

  Copyright (c) 2014 Qualcomm Technologies, Inc. All Rights Reserved.
  Qualcomm Technologies Proprietary and Confidential.

============================================================================*/

#include "af_algo_tuning.h"

static af_algo_ctrl_t af_algo_data = {
#include "dw9714a_p8s04e_camera.h"
};

void *dw9714a_p8s04e_camera_af_algo_open_lib(void)
{
  return &af_algo_data;
}
