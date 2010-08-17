#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS += /target:winexe

#
SOURCES = \
    helloDXForm.cs

TARGETS = $(SOURCES:.cs=.exe)
    
default : $(TARGETS)

.PHONY : clean
clean:
	rm -vf $(TARGETS)

