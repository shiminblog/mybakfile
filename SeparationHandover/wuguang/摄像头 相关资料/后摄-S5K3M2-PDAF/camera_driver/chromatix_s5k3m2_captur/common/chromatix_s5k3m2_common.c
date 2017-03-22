/*============================================================================

  Copyright (c) 2015 Qualcomm Technologies, Inc. All Rights Reserved.
  Qualcomm Technologies Proprietary and Confidential.

============================================================================*/

/*============================================================================
 *                      INCLUDE FILES
 *===========================================================================*/
#include "chromatix_common.h"
#include "sensor_dbg.h"

static chromatix_VFE_common_type chromatix_s5k3m2_parms = {
#include "chromatix_s5k3m2_common.h"
};

/*============================================================================
 * FUNCTION    - load_chromatix -
 *
 * DESCRIPTION:
 *==========================================================================*/
void *load_chromatix(void)
{
  SLOW("chromatix ptr %p", &chromatix_s5k3m2_parms);
  return &chromatix_s5k3m2_parms;
}
