/*!
 * @section LICENSE
 * (C) Copyright 2011~2015 Bosch Sensortec GmbH All Rights Reserved
 *
 * This software program is licensed subject to the GNU General
 * Public License (GPL).Version 2,June 1991,
 * available at http://www.fsf.org/copyleft/gpl.html
 *
 * @filename bmi160_ring.c
 * @date     2014/05/06 16:30
 * @id       "d2ea96c"
 * @version  0.2
 *
 * @brief
 * This file implements moudle function, which add
 * the ring buffer to IIO core.
*/


#include "bmi_iio.h"
#include "bmi160_api.h"
#include "iio.h"
#include "sysfs.h"
#include "ring_sw.h"
#include "sysfs.h"
#include "trigger.h"
#include "trigger_consumer.h"
#include "kfifo_buf.h"

static const struct iio_buffer_setup_ops bmi_buffer_setup_ops = {
	.preenable = &iio_sw_buffer_preenable,
	.postenable = &iio_triggered_buffer_postenable,
	.predisable = &iio_triggered_buffer_predisable,
};

int bmi_allocate_ring(struct iio_dev *indio_dev)
{
	struct iio_buffer *ring;
	int err;

	ring = iio_kfifo_allocate(indio_dev);
	if (!ring) {
		err = -ENOMEM;
		goto error_ret;
	}
	indio_dev->buffer = ring;
	/*setup ring buffer*/
	ring->scan_timestamp = true;
	indio_dev->setup_ops = &bmi_buffer_setup_ops;
	err = iio_buffer_register(indio_dev, indio_dev->channels,
		indio_dev->num_channels);
	if (err) {
		dev_err(indio_dev->dev.parent,
				"bmi configure buffer fail %d\n", err);
		goto error_free_buf;
	}
	return 0;
error_free_buf:
	iio_kfifo_free(indio_dev->buffer);
error_ret:
	return err;
}

void bmi_deallocate_ring(struct iio_dev *indio_dev)
{
	iio_buffer_unregister(indio_dev);
	iio_kfifo_free(indio_dev->buffer);
}



