#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS +=

#
SOURCES = \
    property.cs \
    datatype.cs \
    indexer.cs  \
    array.cs    \
    struct.cs   \
    generic.cs  \
    types.cs    \
    boxing.cs   \
    operator.cs \
    anonymous.cs\
    hashtable.cs\
    nest.cs     \
    queue.cs    \
    stack.cs    \

TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	rm -vf $(TARGETS)

