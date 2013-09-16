# EdifactPropertyPipeline #

Biztalk pipeline that will set UNB properties based on promoted properties in inbound message to pipeline. 

## Usage: ##

Put pipeline component in "Encode" stage of pipeline. EDI assembler must be put in the assemble stage. 

**Properties to set in pipeline:**

* propertyNameSpace - Namespace of your property schema. (for where te properties below should be fetched).
* senderId - Name of promoted property that contains the sender ID.
* senderIdQualifier - Name of promoted property that contains the sender ID qualifier.
* receiverId - Name of promoted property that contains the receiver ID.
* receiverIdQualifier - Name of promoted property that contains the receiver ID qualifier.
