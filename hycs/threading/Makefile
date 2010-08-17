#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS +=

#
SOURCES = \
    helloThread.cs \
    monitor.cs     \
    mutex.cs       \
    threadpool.cs  \

TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	$(RM) $(TARGETS) *.txt

