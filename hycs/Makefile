#
#
#
#
#
include ./make.inc

#
SUBDIRS = console dll form dp basic

default :
	for /d %%x in (${SUBDIRS}) do make -C %%x

.PHONY : clean
clean:
	for /d %%x in (${SUBDIRS}) do make clean -C %%x
	rm -vf ./bin/*
