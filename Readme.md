## Overview
This project is simply a demo of how to register a custom JsonConverter and use it when operating on complex objects.
 
 The use case for setting this whole thing up is just for when a third party package uses their own converters, but the deserialization/serialization doesn't quite work as expected. It can sometimes be better just to roll your own then.