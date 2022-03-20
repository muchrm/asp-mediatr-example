using System.Runtime.Serialization;
using MediatR;

namespace asp_mediatr_example.Commands;

[DataContract]
public class HelloNoHandlerCommand : IRequest<bool>{
    [DataMember]
    public string Name {get;init;}
    public HelloNoHandlerCommand(string name){
        this.Name = name;
    }
}