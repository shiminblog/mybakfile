elan_epl2182.c 放在kernel\drivers\input\misc
elan_interface.h 放在kernel\include\linux\input下面
Makefile:主要添加obj-$(CONFIG_SENSORS_ELAN_EPL2182)	+= elan_epl2182.o
Kconfig:主要添加以下内容：
config SENSORS_ELAN_EPL2182
	tristate "ELAN EPL2182 proximity and ambient light sensor"
	depends on I2C=y
	help
	  If you say yes here you get support for ELAN's light/proximity sensors epl2182.