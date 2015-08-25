using System;
using System.IO;

namespace EBNF_Parser
{
	public class StringStream : Stream
	{
		public StringStream(string str)
		{
			String = str;
		}

		private string _str;
		private long _pos;

		public string String
		{
			get
			{
				return _str;
			}
			set
			{
				_str = value;
				Position = 0;
			}
		}

		public override bool CanRead
		{
			get { return true; }
		}

		public override bool CanSeek
		{
			get { return true; }
		}

		public override bool CanWrite
		{
			get { return false; }
		}

		public override void Flush()
		{
			throw new NotSupportedException();
		}

		public override long Length
		{
			get { return String.Length; }
		}

		public override long Position
		{
			get
			{
				return _pos;
			}
			set
			{
				_pos = value;
			}
		}

		public override int ReadByte()
		{
			return (Position < Length)? (int)String[(int)Position++] : -1;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}
	}
}
