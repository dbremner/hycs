#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS +=

#
SOURCES = \
    delegate.cs \
    strategy.cs \
    proxy.cs    \
    interpreter.cs \


TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	rm -vf $(TARGETS)

