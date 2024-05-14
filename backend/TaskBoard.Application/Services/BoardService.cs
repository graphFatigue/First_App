using AutoMapper;
using Npgsql;
using Sieve.Models;
using TaskBoard.Abstractions.Application;
using TaskBoard.Abstractions.Infrastructure;
using TaskBoard.Common;
using TaskBoard.Common.Exceptions;
using TaskBoard.Common.Models.Board;
using TaskBoard.Domain.Entities;
using TaskBoard.Infrastructure;

namespace TaskBoard.Application.Services
{
    public class BoardService : IBoardService
    {
        private readonly AppDbContext _context;
        private readonly IBoardRepository _boardRepository;
        private readonly IMapper _mapper;

        public BoardService(
            AppDbContext context,
            IBoardRepository boardRepository,
            IMapper mapper)
        {
            _context = context;
            _boardRepository = boardRepository;
            _mapper = mapper;
        }

        public async Task<BoardModel> CreateAsync(CreateBoardModel createBoardModel)
        {
            var board = _mapper.Map<Board>(createBoardModel);

            await _boardRepository.CreateAsync(board);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NpgsqlException($"Board with name {createBoardModel.Name} already exists");
            }

            return _mapper.Map<BoardModel>(board);
        }

        public async Task DeleteAsync(int id)
        {
            var board = await _boardRepository.GetByIdAsync(id)
                ?? throw new NotFoundException($"Board with id {id} was not found");

            _boardRepository.Delete(board);

            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<BoardModel>> GetAllAsync()
        {
            var board = await _boardRepository.GetAllAsync();
            board.OrderByDescending(x => x.Name);
            return _mapper.Map<IEnumerable<BoardModel>>(board);
        }

        public async Task<PagedList<BoardModel>> GetAllWithFilterAsync(SieveModel sieveModel)
        {
            var pagedList = await _boardRepository.GetAllWithFilterAsync(sieveModel);
            var boardModels = _mapper.Map<IEnumerable<BoardModel>>(pagedList.Items);

            var updatedPagedList = PagedList<BoardModel>.Copy(pagedList, boardModels);

            return updatedPagedList;
        }

        public async Task<BoardModel> GetByIdAsync(int id)
        {
            var board = await _boardRepository.GetByIdAsync(id)
           ?? throw new NotFoundException($"Board with id {id} was not found");

            return _mapper.Map<BoardModel>(board);
        }

        public async Task<BoardModel> GetByNameAsync(string name)
        {
            var board = await _boardRepository.GetByNameAsync(name)
                ?? throw new NotFoundException($"Board with id {name} was not found");

            return _mapper.Map<BoardModel>(board);
        }

        public async Task UpdateAsync(UpdateBoardModel updateBoardModel)
        {
            var board = await _boardRepository.GetByIdAsync(updateBoardModel.Id)
           ?? throw new NotFoundException($"Board with id {updateBoardModel.Id} was not found");

            if (!string.IsNullOrWhiteSpace(updateBoardModel.Name))
            {
                board.Name = updateBoardModel.Name;
            }

            _boardRepository.Update(board);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new NpgsqlException($"Board with name {updateBoardModel.Name} already exists");
            }
        }
    }
}
