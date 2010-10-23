#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS += /target:winexe

#
SOURCES = \
    helloForm.cs  \
    screensave.cs \
    checkbox.cs   \
    clickme.cs    \
    layout.cs     \
    treeview.cs   \
    processbar.cs \
    holes.cs      \
    hexview.cs    \
    listbox.cs    \
    listview.cs   \
    native.cs     \
    explorer.cs   \
    colorlistbox.cs \
    msgbox.cs     \


TARGETS = $(SOURCES:.cs=.exe)

default : $(TARGETS)

.PHONY : clean
clean:
	$(RM) $(TARGETS)

