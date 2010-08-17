#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS +=

#
SOURCES = \
    log.cs   \
    trace.cs \


TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	rm -vf $(TARGETS) *.txt

