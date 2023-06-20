using APIGenerateUBL.Application.Dto;

namespace APIGenerateUBL.Application.Interface
{
    public interface IDocumentUbl
    {
        ResponseDto Generate(DocumentDtoRequest request);
    }
}
