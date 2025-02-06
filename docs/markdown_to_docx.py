import os
import pypandoc

def get_markdown_files(directory):
    return [os.path.join(directory, f) for f in os.listdir(directory) if f.endswith('.md')]

def convert_markdown_to_docx(markdown_files, output_file):
    # 读取所有Markdown文件的内容并合并
    markdown_content = ""
    for file in markdown_files:
        with open(file, 'r', encoding='utf-8') as f:
            markdown_content += f.read() + "\n\n"

    # 使用pypandoc将合并后的Markdown内容转换为Word文档
    output = pypandoc.convert_text(markdown_content, 'docx', format='md', outputfile=output_file)
    if output:
        print(f"转换过程中出现错误: {output}")
    else:
        print(f"文档已生成: {output_file}")

if __name__ == "__main__":
    directory = '.'
    output_file = 'v-control docs.docx'
    markdown_files = get_markdown_files(directory)
    convert_markdown_to_docx(markdown_files, output_file)