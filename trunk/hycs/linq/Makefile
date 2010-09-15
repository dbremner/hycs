#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS +=

#
SOURCES = \
    consoleHandler.cs  \


TARGETS = $(SOURCES:.cs=.exe)
    
default : $(TARGETS)

.PHONY : clean
clean:
	$(RM) $(TARGETS) *.txt

