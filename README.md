# PRT Duplicate Hash checker

A quick made tool to obtain from 2 different files all CD Hash Keys with diferent Nicks assossiated.

### Usage
```
HashChecker.exe <path_to_file_1> <path_to_file_2>
```

Where `file 1` has the hashes that we want to verify (assumed to be unique) and `file 2` is the collection of every hash + Nicks


### Example
##### File 1
```
[2015-07-08 19:58:13] M76tsCHc0fJguiy5qs0HZvH6yuF5iy7MplC tagY NAME_1 000.000.000.000
[2015-07-08 19:58:13] zwSD6UV4sazJRsNWtXILwhrEsDBvJCPGAss tagX NAME_2_Alternative 000.000.000.000
[2015-07-08 19:58:13] bdtjPJREBlDQbCqk6mvJz0k34UNv2URRWoY NAME_NOT_PLAYER_5 000.000.000.000
[2015-07-08 19:58:13] krBfxZMEalcwmaf0JX9XuOmivXawDeJ8vqR NAME_4 000.000.000.000

```
##### File 2
```
[2015-07-08 19:58:13] M76tsCHc0fJguiy5qs0HZvH6yuF5iy7MplC tagY NAME_1 000.000.000.000
[2015-07-08 19:58:13] zwSD6UV4sazJRsNWtXILwhrEsDBvJCPGAss tagX NAME_2 000.000.000.000
[2015-07-08 19:58:13] zwSD6UV4sazJRsNWtXILwhrEsDBvJCPGAss tagX NAME_2_Alternative 000.000.000.000
[2015-07-08 19:58:13] zwSD6UV4sazJRsNWtXILwhrEsDBvJCPGAss tagX NAME_2_Alternative_2 000.000.000.000
[2015-07-08 19:58:13] bdtjPJREBlDQbCqk6mvJz0k34UNv2URRWoY PLAYER_5 000.000.000.000
[2015-07-08 19:58:13] krBfxZMEalcwmaf0JX9XuOmivXawDeJ8vqR NAME_4 000.000.000.000
[2015-07-08 19:58:13] 1WsWL80oBrMlLK4AYdlAotEVPZir2juH0kd NAME_6 000.000.000.000

```

##### Output
```
======= HASH: zwSD6UV4sazJRsNWtXILwhrEsDBvJCPGAss
>NAME_2 from 000.000.000.000
>NAME_2_Alternative from 000.000.000.000
>NAME_2_Alternative_2 from 000.000.000.000
======= HASH: bdtjPJREBlDQbCqk6mvJz0k34UNv2URRWoY
>PLAYER_5 from 000.000.000.000
>NAME_NOT_PLAYER_5 from 000.000.000.000
```

