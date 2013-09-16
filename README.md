# EdifactPropertyPipeline #

Biztalk pipeline that will set UNB properties based on promoted properties in inbound message to pipeline. The pipeline will always promote the properties even if it does not find the promoted values from the input message. This is because
the expected behavior of the pipeline is that messages should fail in Biztalk if no party is defined that matches the promoted values.

If no value is found for EDI qualifiers the promoted property will be set to " " (the same as <Not Valued> in the Biztalk console for EDI party configuration.

## Usage: ##

Put pipeline component in "Pre-Assemble" stage of a send pipeline. EDI assembler must be put in the assemble stage. 

**Properties to set in pipeline:**

* propertyNameSpace - Namespace of your property schema. (for where te properties below should be fetched).
* senderId - Name of promoted property that contains the sender ID.
* senderIdQualifier - Name of promoted property that contains the sender ID qualifier.
* receiverId - Name of promoted property that contains the receiver ID.
* receiverIdQualifier - Name of promoted property that contains the receiver ID qualifier.

## Techincal notes: ##

### Properties used: ###

Pipeline will promote properties:

* DestinationPartySenderIdentifier
* DestinationPartyReceiverIdentifier
* DestinationPartySenderQualifier
* DestinationPartyReceiverQualifier
 
These properties have have the namespace "http://schemas.microsoft.com/Edi/PropertySchema"

Even if no value is found in the property bag for **inbound** properties you are trying to use the properties above will be
promoted as blank properties. This is because only when all 4 properties are promoted will the party resolution be done. As
stated above this is done so that Biztalk intentionally will suspend the message if a party is not found. Had this not been done
the message could potentially leave Biztalk with sender / receiver "BTS-sender" and "BTS-receiver" witch are the default values for
the UNB segment.

### Other notes: ###

I was forced to make a copy of the inbound stream to force Biztalk to promote the properties mentioned above. If I do not 
touch the stream and only promote the properties they will not be promoted in time before the message hits the EDI assembler.

