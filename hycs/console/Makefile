#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS +=

#
SOURCES = \
    helloConsole.cs \
    echoConsole.cs  \

TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	$(RM) $(TARGETS)

