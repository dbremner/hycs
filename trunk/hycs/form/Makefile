#
#
#
#
#
SHELL = cmd.exe

#
CSC = csc.exe

#
BINDIR = ../bin

#
CS_FLAGS = /nologo /target:winexe

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


TARGETS = $(SOURCES:.cs=.exe)
    
default : $(TARGETS)

%.exe : %.cs
	$(CSC) $(CS_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@

.PHONY : clean
clean:
	rm -vf $(TARGETS)

