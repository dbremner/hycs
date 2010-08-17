#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS += /target:winexe

#
SOURCES = \
    helloGDIPlus.cs

TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	$(RM) $(TARGETS)

