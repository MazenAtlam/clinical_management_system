using CCMS.BLL.ModelVM.Room;
using CCMS.DAL.Entities;
using Riok.Mapperly.Abstractions;

namespace CCMS.BLL.Mapping
{
    [Mapper]
    public partial class RoomMapper
    {
        // Map Room -> RoomDTO
        public partial RoomDTO ToResponseDto(Room room);
        public partial List<RoomDTO> ToListResponseDto(List<Room> rooms);
    }
}
