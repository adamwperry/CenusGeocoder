# CenusGeocoder
Simple .Net 7 app that uses an api to get address information / geodate from a US street address. 

## Example Input Json 
`This is the format of the json needed for the input file.`

```
{ 
    "addresses": [
        { "address": "4600 Silver Hill Rd Washington DC 20233" },
        { "address": "1900 Pennsylvania Avenue NWWashington DC 20006" }
    ]
}
```


## Example commands
```
-f ~/sample.json -o ~/sample_result.json
```

optional
```
-b 2020 
```

### Argument Help
```
-f input file
-o output file
-b benchmark year (if no argumnet is provide then the default = 2020)
```
