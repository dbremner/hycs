################################################################
#
#
#
################################################################

#
SHELL = cmd.exe

#
CSC = csc.exe

#
RM = rm -vf

#
BINDIR = $(TOPDIR)/bin
ICODIR = $(TOPDIR)/ico

#
CS_FLAGS = /nologo /win32icon:$(ICODIR)/hycs.ico

%.exe : %.cs
	$(CSC) $(CS_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@


