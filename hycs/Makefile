#
#
#
#
#
include ./make.inc

#
SUBDIRS = console dll form dp basic   \
          2d network gdiplus xml      \
          exception threading interop \
          

default :
	for /d %%x in (${SUBDIRS}) do make -C %%x

.PHONY : clean
clean:
	for /d %%x in (${SUBDIRS}) do make clean -C %%x
	rm -vf ./bin/*.exe ./bin/*.dll
