#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS +=

#
SOURCES = \
    oledb.cs \
    myexcel.cs \


TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	rm -vf $(TARGETS)

