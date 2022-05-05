# Stair Tower Cost Estimator

## A program to estimate material cost of a stair tower by reading tower/flight dimensions and calulating individual part dimensions/weights.
___

The program reads a stair configuration JSON as input and performs a series of transformations to create a bill of materials for each flight in the tower. Tranformations are located in the `ce_console.net_4.6.1/transformations` folder and performed using the [JUST.net](https://github.com/WorkMaze/JUST.net) library.

## How To Use

The initial stair config JSON data should be located in the `data` folder and is referenced by the `configFilePath` variable in the first line of the `Main` function body. Set this variable to point at the configuration data and run the program inside the IDE.

## How It Works

### First Transformation: Tower Config Data => Flight Quantites + Lengths

* The first transformation, `constants_transformer.json`, reads through each flight and calculates specific values, based on variables `riseHeight`, `runLength`, `landingWidth`, `landingLength`, `isDogLeg`, `isDdl`, etc. The goal of this transformation is to flesh out the initial config data and provide more detailed and granular values for specific parts.

* The transformation relies on built-in JUST methods for simple operations, and calls outside functions for more complex calculations. These helper methods are located in the `TransformationMethods` class library.

* It outputs a JSON file, located at `output/flightConsts`. Each object contains calculated values per flight for the quantities and lengths needed for the next transformation.

### Second Transformation: Flight Quantites + Lengths => Flight Bill of Materials

* The second transformation, `tower_transformer.json`, creates a bill of materials for each flight. The bill of materials breaks down each flight into separate parts. Each part contains a material id, a quantity of units, a part quantity, and a location description. The material id refers to a material object located in `data/materials.json`.

* The majority of the calculations are located in the first transformation. The second transformation pulls the values from the first, and assigns them to each part. The second transformation only contains logic to determine the material for the stringers, and sums the values for the dog leg, ddl, and ddl extension conditions.
* It outputs to `output/full_tower_output`, which contains a full bill of materials for each flight, with each part having a material, quantity, and quantity of units.

### Deserializing Data and Calculating Part Weight/Price

* Once the transformations are complete, the `full_tower_output.json` and `materials.json` are read into memory and fed into the `TowerCalculator` object. This object iterates through each flight, and through each part in the flight, and feeds the Materials object to the part. The part uses its material id to determine which units the part is measured, and multiplies the quantity of units by the price per unit.
* Once the price for each part has been set, the `PrintFlightPrices()` method will tally the prices for each flight, and print to the console.
* The final step will serialize the collection of flights back to JSON, and write the data to `output/tower_price_output.json`.