#!/usr/bin/env nix-shell
#!nix-shell -i bash -p imagemagick ghostscript

if ! command -v convert &> /dev/null; then
  echo "ImageMagick is not installed. Exiting."
  exit 1
fi

dotnet watch --project Web