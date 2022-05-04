# Stair Tower Cost Estimator

## A program to estimate material cost of a stair tower by reading tower/flight dimensions and calulating individual part dimensions/weights.
___

The program reads a stair configuration JSON as input and performs a series of transformations to create a bill of materials for each flight in the tower. Tranformations are located in the `ce_console.net_4.6.1/transformations` folder and performed using the [JUST.net](https://github.com/WorkMaze/JUST.net) library.

The initial stair config JSON data is located in the `ce_console.net_4.6.1/data` folder and is referenced by the `configFilePath` variable in the first line of the `Main` function body.

### First Transformation: Tower Config Data => Flight Quantites + Lengths

* The first transformation, `constants_transformer.json`, reads through each flight and calculates specific variables for each flight, based on variables `riseHeight`, `runLength`, `landingWidth`, `landingLength`, `isDogLeg`, `isDdl`, etc. The goal of this transformation is to flesh out the initial config data and provide more specific and granular values for specific parts.

* The transformation relies on built in JUST methods for simple operations, and calls outside functions for more complex calculations. These helper methods are located in the `TransformationMethods` class library.

* It outputs a JSON file, located at `ce_console.net_4.6.1/output/flightConsts`. Each object contains calculated values for the quantities and lengths needed for the next transformation.

### Second Transformation: Flight Quantites + Lengths => Flight Bill of Materials
