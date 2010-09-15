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
#MYICON = $(ICODIR)/hycs.ico
MYICON = $(ICODIR)/alter.ico

#
CS_FLAGS = /nologo /win32icon:$(MYICON)

%.exe : %.cs
	$(CSC) $(CS_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@


