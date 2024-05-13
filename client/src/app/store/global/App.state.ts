import { boardReducer } from "../boards/board.reducer";
import { listsReducer } from "../lists/lists.reducer";

export const AppState={
    boardId: boardReducer, 
    lists: listsReducer
}