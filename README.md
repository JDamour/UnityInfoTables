<h1 align="center">Welcome to com.gameframe.infotables 👋</h1>
<p>
  <img alt="Version" src="https://img.shields.io/badge/version-1.0.13-blue.svg?cacheSeconds=2592000" />
  <a href="https://twitter.com/coryleach">
    <img alt="Twitter: coryleach" src="https://img.shields.io/twitter/follow/coryleach.svg?style=social" target="_blank" />
  </a>
</p>

> This is a library for building and maintaining ScriptableObject data tables</br>
> Each entry in a table is its own ScriptableObject.</br>
> Each entry in the table has an ID which can be exported as an enum. </br>
> The exported enum can then be used as a key to get the entry from the table. </br>
> </br>
> The InfoTableProvider class can be used to globally provide a reference to all the info tables in the project </br>
> InfoTableProvider has a serialized reference to all InfoTables so all info tables in the provider will be loaded </br>

## Quick Package Install

#### Using UnityPackageManager (for Unity 2019.3 or later)
Open the package manager window (menu: Window > Package Manager)<br/>
Select "Add package from git URL...", fill in the pop-up with the following link:<br/>
https://github.com/coryleach/UnityInfoTables.git#1.0.13<br/>

#### Using UnityPackageManager (for Unity 2018.3 or later)

Find the manifest.json file in the Packages folder of your project and edit it to look like this:
```js
{
  "dependencies": {
    "com.gameframe.infotables": "https://github.com/coryleach/UnityInfoTables.git#1.0.13",
    ...
  },
}
```

## Author

👤 **Cory Leach**

* Twitter: [@coryleach](https://twitter.com/coryleach)
* Github: [@coryleach](https://github.com/coryleach)

## Show your support

Give a ⭐️ if this project helped you!

***
_This README was generated with ❤️ by [readme-md-generator](https://github.com/kefranabg/readme-md-generator)_
