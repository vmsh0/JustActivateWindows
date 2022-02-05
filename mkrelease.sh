#!/bin/sh

cd release

VER=`sed -e 's/xmlns="[^"]*"//g' ../jaw/jaw.csproj | xmllint --xpath "/Project/PropertyGroup/ApplicationVersion/text()" -`
BVER=`echo $VER | sed -e 's/%2a/0/g'`

RELDIR="jaw-v$BVER"
RELTARGET="$RELDIR.zip"

echo "Make release dir"
if [ -d "$RELDIR" ]; then rm -r "$RELDIR"; fi
mkdir "$RELDIR"

if [ -f "../jaw/bin/Release/jaw.exe" ]; then
	echo "Copy jaw.exe to release dir"
	cp "../jaw/bin/Release/jaw.exe" "$RELDIR/jaw.exe"
else
	echo "Release binary absent."
	exit 1
fi

echo "Copy package files to release dir"
cp "package/"* "$RELDIR"

echo "Zip release"
if [ -f "$RELTARGET" ]; then rm "$RELTARGET"; fi
zip -r "$RELTARGET" "$RELDIR"

