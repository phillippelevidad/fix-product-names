# Tool for fixing names

This is a simple tool to fix names (like product names) usig Regular Expressions.

## Data Files

The `inputs.xlsx` file lists all names to be fixed in the first column.

The `transformations.xlsx` file lists all Regular Expressions + Substitutions that will be applied to the names in the first file.

## How it works

1. The tool reads the names and regex transformations from the data files;
1. The tool applies all transformations, in order, to all names;
1. It outputs a new file with the original vs transformed names to a `results.xlsx` in your desktop.

PS. default transformations are applied in addition to the ones specified in the transformations file. These are the `Sanitize` and `Case` transformations, which remove duplicated characteres (like double whitespaces) and convert to Title Case, respectively.