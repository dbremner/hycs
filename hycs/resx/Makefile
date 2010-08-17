#
TOPDIR = ..
#
#
#
include $(TOPDIR)/make.inc

#
CS_FLAGS += /res:StringTable.resx

#
SOURCES = \
    resource.cs \
    string.cs   \


TARGETS = $(SOURCES:.cs=.exe)
    
default : $(TARGETS)

%.exe : %.cs
	$(CSC) $(CS_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@
    
resource.exe : resource.cs StringTable.resx
	$(CSC) $(CS_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@

%.resx : %.txt
	resgen $< $@

.PHONY : clean
clean:
	rm -vf $(TARGETS)

