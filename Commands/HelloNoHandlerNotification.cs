using System.Runtime.Serialization;
using MediatR;

namespace asp_mediatr_example.Commands;

[DataContract]
public class HelloNoHandlerNotification : INotification{
    [DataMember]
    public string Name {get;init;}
    public HelloNoHandlerNotification(string name){
        this.Name = name;
    }
}