class OpenCloseTag{
    openTag: string;
    closeTag: string;

    constructor(openTag: string, closeTag: string) {
        this.openTag = openTag;
        this.closeTag = closeTag;
    }
}

const validTags: string[] = ['(', ')', '[', ']', '{', '}']

const tags: OpenCloseTag[] = [ 
    new OpenCloseTag(validTags[0], validTags[1]),
    new OpenCloseTag(validTags[2], validTags[3]),
    new OpenCloseTag(validTags[4], validTags[5])
];

function getOppositeTag(openCloseTag: string): string {
    // if index is -1 the tag is invalid and doesn't exists in the array
    if (validTags.indexOf(openCloseTag) == -1) {
        throw new Error('String passed in is not a valid tag');
    }
    for (let tag of tags) {
        if (openCloseTag == tag.openTag) {
            return tag.closeTag;
        } else if (openCloseTag == tag.closeTag) {
            return tag.openTag;
        }
    }
}

function isMatching(pattern: string ): boolean {
    let stack: string[] = []

    // Basic even/odd check first
    if (pattern.length % 2 != 0) {
        // lenght is odd | not closed
        return false;
    }
    for (let tagIndex = 0; tagIndex < pattern.length; tagIndex++) {
        // open Tag handler
        if (pattern[tagIndex] === tags[0].openTag || pattern[tagIndex] === tags[1].openTag || pattern[tagIndex] === tags[2].openTag) {
            stack.push(pattern[tagIndex])
        }
        // close tag handler 
        else {
            if (pattern[tagIndex] !== getOppositeTag(stack.pop())) { return false; }
        }
    }
    // if stack is not empty it's missing a tag
    if (stack.length !== 0 ) { return false; }
    return true;
};

console.log(isMatching('{'));
console.log(isMatching('([((({()})))])')); // true
console.log(isMatching('([((({()}))))'));  // false
console.log(isMatching("(){}")); // true
console.log(isMatching("[{()()}({[]})]({}[({})])((((((()[])){}))[]{{{({({({{{{{{}}}}}})})})}}}))[][][]")); // true
console.log(isMatching("({(()))}}"));  // false
