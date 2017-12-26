import os,sys
import shutil

pathname = []
def cp_file(rootdir):
    #print "dirpath = %s\n" % dirpath
    #for root, dirs in os.walk(dirpath):
    for root, dirs, files in os.walk(rootdir):
        for dirname in dirs:
            newdir = []
            dirname = os.path.join(root, dirname)
            print "dirname = %s" % dirname
            if os.path.exists(dirname):
                newdir = pathname + dirname

            print "newdir = %s\n" % newdir
            if newdir != dirname and os.path.exists(newdir) == False:
                os.makedirs(newdir)

        for filename in files:
            srcfile = os.path.join(root, filename)
            desfile = pathname + srcfile
            print "srcfile = %s\n" % srcfile
            srcfile = os.path.splitext(srcfile)
            if srcfile[1] == ".c" or srcfile[1] == ".cpp" or srcfile[1] == ".java" or srcfile[1] == ".h":
                suffix = ".text"
                file_name,file_extend = os.path.splitext(desfile)
                desfile = file_name + file_extend + suffix
            srcfile = os.path.join(root, filename)
            #desfile = os.path.splitext(desfile)
            print "srcfile_111 = %s\n" % srcfile
            print "desfile = %s\n" % desfile
            shutil.copyfile(srcfile, desfile)

def rename_file(rootdir):
    for root, dirs, files in os.walk(rootdir):
        for filename in files:
            oldfile = os.path.splitext(os.path.join(root, filename))
            newfile = []
            if oldfile[1] == ".text":
                newfile = oldfile[0] + ""
                print "oldfile = %s\n" % (os.path.join(root, filename))
                print "newfile =%s\n" % newfile
                os.rename(os.path.join(root, filename), newfile)


if __name__ == "__main__":
    para_num = len(sys.argv)
    if para_num < 3:
        print "Usage: python search_file.py [name of rootdir] [outdir],for example:\n"
        print "python search_file.py kernel /home/shaomingliang/SML/ \n"
        exit(0)
    pathname = sys.argv[2]
    cp_file(sys.argv[1])
    #rename_file(".")
