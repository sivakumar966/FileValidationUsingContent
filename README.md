# File Format Detection for Secure File Uploads

This project implements a security measure to detect the true format of a file by reading its binary header, bypassing the reliance on file extensions. This is particularly useful for preventing attackers from uploading malicious files with fake extensions, ensuring that only approved file formats are accepted.

## Key Features

- **Binary Header Reading**: The first 10 bytes of a file are read to determine its format based on the file's magic number (a unique sequence of bytes at the beginning of the file that identifies its type).
  
- **Supported Formats**: The project supports a predefined set of file formats such as JPG, PNG, and PDF. Each format is associated with its specific magic number, stored in a dictionary for quick reference.

- **Content-Based File Validation**: By analyzing the file's binary content rather than its extension, the system prevents attackers from renaming malicious files (e.g., a `.exe` file renamed to `.jpg`) and uploading them as legitimate formats.

- **Flexible Security**: The allowed formats and their corresponding magic numbers can be easily updated to support additional file types or to tighten security as needed.

## Workflow

1. **File Upload**: When a file is uploaded, its binary content is read, and the first 10 bytes are extracted to get its magic number.

2. **Format Identification**: The extracted magic number is then compared with the known values for allowed file formats. If a match is found, the file’s actual format is identified.

3. **Validation**: The system verifies whether the identified file format is allowed based on a predefined list of acceptable formats. If the format is not on the list or cannot be identified, the file is rejected.

4. **Security Enhancements**: This approach prevents malicious files from bypassing security by disguising themselves with safe-looking file extensions.

## Benefits

- **Increased Security**: Provides a layer of security beyond file extensions, ensuring that only files with valid and allowed content are uploaded.
- **Protection from Malicious Files**: Helps avoid common attacks where malicious files are renamed to bypass filters.
- **Scalability**: The solution can easily be extended to support more file formats by adding their corresponding magic numbers.

---

This solution is especially useful for applications with file upload functionality, where maintaining the integrity of uploaded content is crucial for security.
