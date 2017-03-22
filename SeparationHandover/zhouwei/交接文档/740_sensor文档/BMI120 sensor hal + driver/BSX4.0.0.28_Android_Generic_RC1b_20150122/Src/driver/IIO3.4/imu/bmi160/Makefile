#
#Makefile for BMI160 IIO Driver
#
obj-$(CONFIG_SENSORS_BMI160)  += bmi160_core.o bmi160_api.o bmi160_i2c.o bmi160_ring.o
ifeq ($(CONFIG_BMI160_MAG_INTERFACE_SUPPORT),y)
		EXTRA_CFLAGS += -DBMI160_MAG_INTERFACE_SUPPORT
endif
ifeq ($(CONFIG_SENSORS_BMI160_ENABLE_INT1),y)
		EXTRA_CFLAGS += -DBMI160_ENABLE_INT1
endif

ifeq ($(CONFIG_BMI160_DEBUG),y)
		EXTRA_CFLAGS += -DBMI160_DEBUG
endif

ifeq ($(CONFIG_SENSORS_BMI160_ENABLE_INT2),y)
		EXTRA_CFLAGS += -DBMI160_ENABLE_INT2
endif

CFLAGS_bmi160_core.o +=  -Idrivers/staging/iio
CFLAGS_bmi160_api.o +=  -Idrivers/staging/iio
CFLAGS_bmi160_i2c.o +=  -Idrivers/staging/iio
CFLAGS_bmi160_ring.o +=  -Idrivers/staging/iio

EXTRA_CFLAGS += -DBMI_USE_BASIC_I2C_FUNC
