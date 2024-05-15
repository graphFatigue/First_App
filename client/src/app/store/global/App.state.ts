import { boardReducer } from "../boards/board.reducer";
import { cardReducer } from "../cards/card.reducer";
import { listReducer } from "../list/list.reducer";
import { listsReducer } from "../lists/lists.reducer";

export const AppState={
    id: boardReducer, 
    lists: listsReducer,
    card: cardReducer,
    list: listReducer
}