#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS +=

#
SOURCES = \
    redirectIO.cs \
    readfile.cs

TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	$(RM) $(TARGETS)

