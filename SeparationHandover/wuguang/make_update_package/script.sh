export PATH=./ota_diff_package:$PATH
export OUT_HOST_ROOT=./ota_diff_package
./ota_diff_package/ota_from_target_files -p $OUT_HOST_ROOT -f 1 -v $1 update.zip