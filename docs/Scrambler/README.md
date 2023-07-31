# Tools.Scrambler

This library has utilities to shuffle lists of generic types using the Fisher–Yates shuffle algorithm.

## Quick Installation Guide

### Install Package

```shell 

dotnet add package Menso.Tools.Scrambler

```

## Usage

### Use cases:

```csharp
var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
var seed = 123;

list.Shuffle(); // shuffles the list randomly
// or
list.Shuffle(seed); // shuffles the list always the same way, depending on the seed
// or
list.CryptoStrongShuffle(); // shuffles the list using the CryptoRandom class

```

### We are open to suggestions and collaborations