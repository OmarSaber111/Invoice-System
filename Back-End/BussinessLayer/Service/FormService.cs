using ApiContract.Dtos;
using ApiContracts;
using AutoMapper;
using BussinessLayer.InterFaces;
using DataLayer.InterFaces;
using Models.Entities;

namespace BussinessLayer.Service
{
    public class FormService : IFormService
    {
        private readonly IFormRepository _formRepo;
        private readonly IMapper _mapper;

        public FormService(IFormRepository formRepo, IMapper mapper)
        {
            _formRepo = formRepo;
            _mapper = mapper;
        }

        public async Task<GResponse<IEnumerable<FormDto>>> GetAllFormsAsync()
        {
            var forms = await _formRepo.GetAllFormsAsync();
            var result = _mapper.Map<IEnumerable<FormDto>>(forms);
            return GResponse<IEnumerable<FormDto>>.CreateSuccess(result);
        }

        public async Task<GResponse<FormDto>> GetFormByIdAsync(int id)
        {
            var form = await _formRepo.GetFormByIdAsync(id);
            if (form == null)
                return GResponse<FormDto>.CreateFailure("404", "Form not found");

            var result = _mapper.Map<FormDto>(form);
            return GResponse<FormDto>.CreateSuccess(result);
        }

        public async Task<GResponse<FormDto>> CreateFormAsync(CreateFormDto dto)
        {
            var form = _mapper.Map<Form>(dto);
            await _formRepo.InsertAsync(form);
            await _formRepo.Commit();

            var result = _mapper.Map<FormDto>(form);
            return GResponse<FormDto>.CreateSuccess(result);
        }

        public async Task<GResponse<string>> UpdateFormAsync(UpdateFormDto dto)
        {
            var form = await _formRepo.GetFormByIdAsync(dto.FormId);
            if (form == null)
                return GResponse<string>.CreateFailure("404", "Form not found");

            _mapper.Map(dto, form);

            await _formRepo.Commit();

            return GResponse<string>.CreateSuccess("Form updated successfully.");
        }

        public async Task<GResponse<bool>> DeleteFormAsync(int id)
        {
            var form = await _formRepo.GetFormByIdAsync(id);
            if (form == null)
                return GResponse<bool>.CreateFailure("404", "Form not found");

            _formRepo.Delete(form);
            await _formRepo.Commit();

            return GResponse<bool>.CreateSuccess(true);
        }
    }

}
