# CloudSyncUtil

##Description

This tool allows you to sync custom files/path from fylesystem to your Gdrive/Dropbox account just by hitting the .exe file.

##Configuration

Configuring is very simple. 

### Paths
The only thing that you need to specify is the pipe-separated file list for sync in the <b>App.config</b> file:

```<add key="Google.Files" value="D://my/myfolder/test.txt | C://other/otherfolder/myfile2.txt" />```

By default it will force the same folder structure as it was on the file system.

If you want to <b>change the folder structure</b>, you can specify a new path after <i>semicolon</i>:

```<add key="Google.Files" value="D://my/myfolder/myfile.txt;new/newfolder/" />```

### Wildcards
It also supports <b>wildcards</b>, as follows:

One asterisk (`*`) will sync ALL files UNDER <i>myfolder</i> (not including inner folders)

```<add key="Google.Files" value="D://my/myfolder/*" />```

Two asterisks (`**`) will sync ALL files UNDER <i>myfolder</i> RECURSIVELY:

```<add key="Google.Files" value="D://my/myfolder/**" />```

### Advanced

There is a number of advanced configuration options that probably should not be changed. 

All those options are documented inside the App.config file.

Make sure that you know what you doing when you change them. 

Personally, I don't see a scenario when you ever will need to change those. 
