#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS += /doc:helloXML.xml

#
SOURCES = \
    helloXML.cs

TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	rm -vf $(TARGETS) *.xml

