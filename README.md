# EdifactPropertyPipeline #

Biztalk pipeline that will set UNB properties based on promoted properties in inbound message to pipeline. The pipeline will always promote the properties even if it does not find the promoted values from the input message. This is because
the expected behavior of the pipeline is to fail the file on missing EDI party.

If no value is found for EDI qualifiers the promoted property will be set to " " (the same as <Not Valued> in the Biztalk console for EDI party configuration.

## Usage: ##

Put pipeline component in "Pre-Assemble" stage of a send pipeline. EDI assembler must be put in the assemble stage. 

**Properties to set in pipeline:**

* propertyNameSpace - Namespace of your property schema. (for where te properties below should be fetched).
* senderId - Name of promoted property that contains the sender ID.
* senderIdQualifier - Name of promoted property that contains the sender ID qualifier.
* receiverId - Name of promoted property that contains the receiver ID.
* receiverIdQualifier - Name of promoted property that contains the receiver ID qualifier.
