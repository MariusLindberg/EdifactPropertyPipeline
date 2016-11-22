namespace org.skuzznet
{
    using System;
    using System.IO;
    using System.Text;
    using System.Drawing;
    using System.Resources;
    using System.Reflection;
    using System.Diagnostics;
    using System.Collections;
    using System.ComponentModel;
    using Microsoft.BizTalk.Message.Interop;
    using Microsoft.BizTalk.Component.Interop;
    using Microsoft.BizTalk.Component;
    using Microsoft.BizTalk.Messaging;
    using Microsoft.BizTalk.Streaming;
    
    
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [System.Runtime.InteropServices.Guid("12230dcb-ae72-49f4-aac7-c3d36ef5a8d2")]
    [ComponentCategory(CategoryTypes.CATID_Any)]
    public class EdifactPropertyPipeline : Microsoft.BizTalk.Component.Interop.IComponent, IBaseComponent, IPersistPropertyBag, IComponentUI
    {
        
        private System.Resources.ResourceManager resourceManager = new System.Resources.ResourceManager("org.skuzznet.EdifactPropertyPipeline", Assembly.GetExecutingAssembly());

        private string _edifactPropertyNamespace = "http://schemas.microsoft.com/Edi/PropertySchema";

        private string _senderId;
        
        public string senderId
        {
            get
            {
                return _senderId;
            }
            set
            {
                _senderId = value;
            }
        }
        
        private string _propertyNameSpace;
        
        public string propertyNameSpace
        {
            get
            {
                return _propertyNameSpace;
            }
            set
            {
                _propertyNameSpace = value;
            }
        }
        
        private string _receiverId;
        
        public string receiverId
        {
            get
            {
                return _receiverId;
            }
            set
            {
                _receiverId = value;
            }
        }
        
        private string _senderIdQualifier;
        
        public string senderIdQualifier
        {
            get
            {
                return _senderIdQualifier;
            }
            set
            {
                _senderIdQualifier = value;
            }
        }
        
        private string _receiverIdQualifier;
        
        public string receiverIdQualifier
        {
            get
            {
                return _receiverIdQualifier;
            }
            set
            {
                _receiverIdQualifier = value;
            }
        }
        
        #region IBaseComponent members
        /// <summary>
        /// Name of the component
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get
            {
                return resourceManager.GetString("COMPONENTNAME", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        
        /// <summary>
        /// Version of the component
        /// </summary>
        [Browsable(false)]
        public string Version
        {
            get
            {
                return resourceManager.GetString("COMPONENTVERSION", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        
        /// <summary>
        /// Description of the component
        /// </summary>
        [Browsable(false)]
        public string Description
        {
            get
            {
                return resourceManager.GetString("COMPONENTDESCRIPTION", System.Globalization.CultureInfo.InvariantCulture);
            }
        }
        #endregion
        
        #region IPersistPropertyBag members
        /// <summary>
        /// Gets class ID of component for usage from unmanaged code.
        /// </summary>
        /// <param name="classid">
        /// Class ID of the component
        /// </param>
        public void GetClassID(out System.Guid classid)
        {
            classid = new System.Guid("12230dcb-ae72-49f4-aac7-c3d36ef5a8d2");
        }
        
        /// <summary>
        /// not implemented
        /// </summary>
        public void InitNew()
        {
        }
        
        /// <summary>
        /// Loads configuration properties for the component
        /// </summary>
        /// <param name="pb">Configuration property bag</param>
        /// <param name="errlog">Error status</param>
        public virtual void Load(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, int errlog)
        {
            object val = null;
            val = this.ReadPropertyBag(pb, "senderId");
            if ((val != null))
            {
                this._senderId = ((string)(val));
            }
            val = this.ReadPropertyBag(pb, "propertyNameSpace");
            if ((val != null))
            {
                this._propertyNameSpace = ((string)(val));
            }
            val = this.ReadPropertyBag(pb, "receiverId");
            if ((val != null))
            {
                this._receiverId = ((string)(val));
            }
            val = this.ReadPropertyBag(pb, "senderIdQualifier");
            if ((val != null))
            {
                this._senderIdQualifier = ((string)(val));
            }
            val = this.ReadPropertyBag(pb, "receiverIdQualifier");
            if ((val != null))
            {
                this._receiverIdQualifier = ((string)(val));
            }
        }
        
        /// <summary>
        /// Saves the current component configuration into the property bag
        /// </summary>
        /// <param name="pb">Configuration property bag</param>
        /// <param name="fClearDirty">not used</param>
        /// <param name="fSaveAllProperties">not used</param>
        public virtual void Save(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, bool fClearDirty, bool fSaveAllProperties)
        {
            this.WritePropertyBag(pb, "senderId", this.senderId);
            this.WritePropertyBag(pb, "propertyNameSpace", this.propertyNameSpace);
            this.WritePropertyBag(pb, "receiverId", this.receiverId);
            this.WritePropertyBag(pb, "senderIdQualifier", this.senderIdQualifier);
            this.WritePropertyBag(pb, "receiverIdQualifier", this.receiverIdQualifier);
        }
        
        #region utility functionality
        /// <summary>
        /// Reads property value from property bag
        /// </summary>
        /// <param name="pb">Property bag</param>
        /// <param name="propName">Name of property</param>
        /// <returns>Value of the property</returns>
        private object ReadPropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, string propName)
        {
            object val = null;
            try
            {
                pb.Read(propName, out val, 0);
            }
            catch (System.ArgumentException )
            {
                return val;
            }
            catch (System.Exception e)
            {
                throw new System.ApplicationException(e.Message);
            }
            return val;
        }
        
        /// <summary>
        /// Writes property values into a property bag.
        /// </summary>
        /// <param name="pb">Property bag.</param>
        /// <param name="propName">Name of property.</param>
        /// <param name="val">Value of property.</param>
        private void WritePropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag pb, string propName, object val)
        {
            try
            {
                pb.Write(propName, ref val);
            }
            catch (System.Exception e)
            {
                throw new System.ApplicationException(e.Message);
            }
        }
        #endregion
        #endregion
        
        #region IComponentUI members
        /// <summary>
        /// Component icon to use in BizTalk Editor
        /// </summary>
        [Browsable(false)]
        public IntPtr Icon
        {
            get
            {
                return ((System.Drawing.Bitmap)(this.resourceManager.GetObject("COMPONENTICON", System.Globalization.CultureInfo.InvariantCulture))).GetHicon();
            }
        }
        
        /// <summary>
        /// The Validate method is called by the BizTalk Editor during the build 
        /// of a BizTalk project.
        /// </summary>
        /// <param name="obj">An Object containing the configuration properties.</param>
        /// <returns>The IEnumerator enables the caller to enumerate through a collection of strings containing error messages. These error messages appear as compiler error messages. To report successful property validation, the method should return an empty enumerator.</returns>
        public System.Collections.IEnumerator Validate(object obj)
        {
            // example implementation:
            // ArrayList errorList = new ArrayList();
            // errorList.Add("This is a compiler error");
            // return errorList.GetEnumerator();
            return null;
        }
        #endregion
        
        #region IComponent members
        /// <summary>
        /// Implements IComponent.Execute method.
        /// </summary>
        /// <param name="pc">Pipeline context</param>
        /// <param name="inmsg">Input message</param>
        /// <returns>Original input message</returns>
        /// <remarks>
        /// IComponent.Execute method is used to initiate
        /// the processing of the message in this pipeline component.
        /// </remarks>
        public Microsoft.BizTalk.Message.Interop.IBaseMessage Execute(Microsoft.BizTalk.Component.Interop.IPipelineContext pc, Microsoft.BizTalk.Message.Interop.IBaseMessage inmsg)
        {
            #region Copy input stream

            try
            {
                IBaseMessagePart bodyPart = inmsg.BodyPart;

                if (bodyPart != null)
                {
                    Stream originalStream = bodyPart.GetOriginalDataStream();

                    // Biztalk will not do property promotion in time if we do not touch the stream. Seems to be a quirk of how the send pipeline works.
                    // If original message is returned no property promotion will happen before the EDI assembler component gets the message.
                    if (originalStream != null)
                    {
                        StreamReader sReader = new StreamReader(originalStream);
                        VirtualStream vStream = new VirtualStream();
                        StreamWriter sWriter = new StreamWriter(vStream);

                        //Write message body to a virutal memory stream 
                        sWriter.Write(sReader.ReadToEnd());
                        sWriter.Flush();
                        sReader.Close();

                        vStream.Seek(0, SeekOrigin.Begin); 

                        pc.ResourceTracker.AddResource(vStream);
                        inmsg.BodyPart.Data = vStream;
                    }
                }

                #endregion

                #region Property promotion

                // Set the identificators. Make sure to set " " if missing to get property promoted (will make Biztalk fail the file on missing party)
                if (string.IsNullOrEmpty((string)inmsg.Context.Read(_senderId, _propertyNameSpace)))
                {
                    inmsg.Context.Promote("DestinationPartySenderIdentifier", _edifactPropertyNamespace, " ");
                }
                else
                {
                    inmsg.Context.Promote("DestinationPartySenderIdentifier", _edifactPropertyNamespace,
                        inmsg.Context.Read(_senderId, _propertyNameSpace));
                }

                if (string.IsNullOrEmpty((string)inmsg.Context.Read(_receiverId, _propertyNameSpace)))
                {
                    inmsg.Context.Promote("DestinationPartyReceiverIdentifier", _edifactPropertyNamespace, " ");
                }
                else
                {
                    inmsg.Context.Promote("DestinationPartyReceiverIdentifier", _edifactPropertyNamespace,
                        inmsg.Context.Read(_receiverId, _propertyNameSpace));
                }

                // If no qualifier is set in pipeline use " " since that will resolve as <no qualifier> in Biztalk.
                if (string.IsNullOrEmpty(_senderIdQualifier))
                    inmsg.Context.Promote("DestinationPartySenderQualifier", _edifactPropertyNamespace, " ");
                else
                {
                    // If no value is found on property set space as value (<No qualifier>)
                    if(string.IsNullOrEmpty((string) inmsg.Context.Read(_senderIdQualifier, _propertyNameSpace)))
                    {
                        inmsg.Context.Promote("DestinationPartySenderQualifier", _edifactPropertyNamespace, " ");
                    }
                    else
                    {
                    inmsg.Context.Promote("DestinationPartySenderQualifier", _edifactPropertyNamespace,
                        inmsg.Context.Read(_senderIdQualifier, _propertyNameSpace));
                    }
                }

                // If no qualifier is set in pipeline use " " since that will resolve as <no qualifier> in Biztalk.
                if (string.IsNullOrEmpty(_receiverIdQualifier))
                    inmsg.Context.Promote("DestinationPartyReceiverQualifier", _edifactPropertyNamespace, " ");
                else
                {
                    // If no value is found on property set space as value (<No qualifier>)
                    if (string.IsNullOrEmpty((string)inmsg.Context.Read(_receiverIdQualifier, _propertyNameSpace)))
                    {
                        inmsg.Context.Promote("DestinationPartyReceiverQualifier", _edifactPropertyNamespace, " ");
                    }
                    else
                    {
                        inmsg.Context.Promote("DestinationPartyReceiverQualifier", _edifactPropertyNamespace,
                            inmsg.Context.Read(_receiverIdQualifier, _propertyNameSpace));
                    }
                }
                return inmsg;

                #endregion
            }
            catch(Exception ex)
            {
                if (inmsg != null)
                {
                    inmsg.SetErrorInfo(ex);
                }

                throw;
            }
        }

        #endregion
    }
}
