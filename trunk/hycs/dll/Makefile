#
TOPDIR = ..

#
include $(TOPDIR)/make.inc

#
CS_FLAGS += /reference:helloDLL.dll
LIB_FLAGS = /nologo /target:library

#
LIB_SOURCES = \
    helloDLL.cs

LIBRARIES = $(LIB_SOURCES:.cs=.dll)

SOURCES = \
    testDLL.cs

EXECUTIVES = $(SOURCES:.cs=.exe)

NATIVE_SRCS = \
   nativeDLL.c

NAV_LIBRARIES = $(NATIVE_SRCS:.c=.dll)

default : $(LIBRARIES) $(EXECUTIVES) $(NAV_LIBRARIES)

%.dll: %.cs
	$(CSC) $(LIB_FLAGS) /out:$@ $<
	cp -v $@ $(BINDIR)/$@

$(NAV_LIBRARIES) : $(NATIVE_SRCS)
	cl /nologo /LD $<

.PHONY : clean
clean:
	$(RM) $(EXECUTIVES) $(LIBRARIES) $(NAV_LIBRARIES) *.lib *.exp *.obj

