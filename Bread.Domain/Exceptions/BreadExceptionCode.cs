using System;
using System.Collections.Generic;
using System.Text;

namespace Bread.Domain.Exceptions
{
    public enum BreadExceptionCode
    {
        GroupIdIsUnknown,
        GroupIsClosed,
        AlbumIdIsUnknown,
        AlbumIsClosed,
        UserIsUnknown,
        UserIsDenied,
        PostIdIsUnknown,
        PostIdIsClosed,
    }
}
